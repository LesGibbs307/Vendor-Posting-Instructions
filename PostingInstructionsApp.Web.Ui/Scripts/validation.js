/*eslint-disable */

var toggleBtnOnForm = function () {
    $(".modal-body").find(".submit").children().toggleClass("hidden");
};

var setData = function () {
    toggleBtnOnForm();
    if ($(".new-vendor").is(":hidden")) {
        var client = $(".client").html();
        var vendor = $(".vendor").html();
    } else {
        var client = $("#popup-form option").filter(":selected").val();
        var vendor = $("#popup-form input").val();
    }
    $("#client").val(client);
    $("#vendor").val(vendor)
};

var formSuccess = function (results) {
    window.location.replace("../thank-you/");
};

var formFailure = function (results) {
    alert("Try Again");
    toggleBtnOnForm();
    $("#popup-form input, #popup-form select").addClass("bg-danger");
};

var passExistingClientVendorData = function () {
    var client = $(".pending");
    var vendor = $(".vendor-list").find(".selected");
    var clientBtn = $(".existing-vendor .client");
    var vendorBtn = $(".existing-vendor .vendor");
    clientBtn.html(client.find("input").val());
    vendorBtn.html(vendor.find("span").html());
    var newHTML = $(".existing-vendor p").html("Are you ready to add " + vendorBtn.html() + " to " + clientBtn.html());
};

var switchArrows = function () {
    var leftArrow = $(".left");
    var rightArrow = $(".right");
    var animatedArrow = $(".highlight");

    if (leftArrow.is(animatedArrow)) {
        leftArrow.stop().removeClass("selected-arrow-left highlight");
        rightArrow.addClass("highlight selected-arrow-right");
    } else {
        rightArrow.stop().removeClass("selected-arrow-right highlight");
        leftArrow.addClass("highlight selected-arrow-left");
    }
    animatedArrow = $(".highlight");
    animateThis(animatedArrow, 400);
};

var animateThis = function (targetElement, speed) {
    targetElement.animate({ left: "+=5px" },
    {
        duration: speed,
        complete: function () {
            targetElement.animate({ left: "-=5px" },
            {
                duration: speed,
                complete: function () {
                    animateThis(targetElement, speed);
                }
            });
        }
    });
};

var enableVendors = function () {
    $(".get-vendor-btn").addClass("disabled");
    $(".client-list").find("li").removeClass("selected")
                                .addClass("disabled");
    $(".vendor-list").find("li").removeClass("disabled selected")
                                .find(".auth-key").addClass("hidden");
    switchArrows();
};

var setVendor = function ($this, client, vendor) {
    var authKey = $(".auth-key");
    authKey.addClass("hidden");
    vendor.removeClass("selected");
    getClientFromVendor($this, client, vendor);
};

var getClientFromVendor = function ($this, client, vendor) {
    var thisVal = $this.find("input").val();
    client.removeClass("disabled selected");

    for (var i = 0; i < data.length; i++) {
        var thisJson = data[i];
        if ($this.is(vendor) && thisVal == thisJson.vendorName) {
            var thisVendor = $("." + thisJson.vendorName);
            var authKey = $(".auth-key");
            var thisClient = $("." + thisJson.clientName);
            if (thisJson.clientName == "American Home Shield") {
                $(".American").removeClass("disabled").addClass("selected");
            } else if (thisJson.clientName == "BackPain Centers") {
                $(".BackPain").removeClass("disabled").addClass("selected");
            } else {
                thisClient.removeClass("disabled").addClass("selected");
            }
            thisVendor.removeClass("disabled").addClass("selected");
        }
    }
};

var getVendorFromClient = function ($this, client, vendor) {
    var thisVal = $this.find("input").val();
    vendor.removeClass("selected").addClass("disabled")
                                  .find(".auth-key").addClass("hidden");

    for (var i = 0; i < data.length; i++) {
        var thisJson = data[i];
        if ($this.is(client) && thisVal == thisJson.clientName) {
            var thisVendor = $("." + thisJson.vendorName);
            var authKey = thisVendor.find($(".auth-key"));
            thisVendor.removeClass("disabled").addClass("selected");
            thisVendor.find(authKey.html(thisJson.authKey)).removeClass("hidden");
            client.removeClass("disabled");
        }
    }
};

var setClient = function ($this, client, vendor) {
    client.removeClass("selected");
    $this.removeClass("disabled").addClass("selected");
    getVendorFromClient($this, client, vendor);
};

var findRelations = function ($this) {
    var client = $(".client-list").find("li");
    var vendor = $(".vendor-list").find("li");
    var selection = window.getSelection();

    if (selection.type == "Caret") {
        if (client.hasClass("selected") && vendor.hasClass("selected") && $(".get-vendor-btn").hasClass("disabled")) {
            if ($this.is(":not(.selected)") && $this.is(client)) {
                $this.addClass("pending");
                passExistingClientVendorData();
                $('#popup-form').modal('show').find(".container").toggleClass("hidden");
            } else {
                client.removeClass("pending");
                setVendor($this, client, vendor);
            }
        } else if ($this.is(client)) {
            setClient($this, client, vendor);
        } else {
            setVendor($this, client, vendor);
        }
    }
};

$(document).ready(function () {
    var animatedArrow = $(".left").addClass("highlight");
    animateThis(animatedArrow, 400);

    $(".client-vendor-list li").on("click", function () {
        var $this = $(this);
        findRelations($this);
    });

    $('#popup-form').on('hidden.bs.modal', function () {
        if ($(".new-vendor").is($(".hidden"))) {
            $('#popup-form').find(".container").toggleClass("hidden");
            $(".client-vendor-list").find(".pending").removeClass("pending");
        }
    });
});

/*eslint-enable */
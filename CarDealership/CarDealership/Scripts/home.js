(function ($, window, document, undefined) {
    "use strict";

    function fetchData() {
        var carOptions = {
            "Color": "Black",
            "IsAutomatic": $(".include-automatic").is(":checked"),
            "HasSunRoof": $(".include-sunroof").is(":checked"),
            "IsFourWheelDrive": $(".include-fourwheeldrive").is(":checked"),
            "HasLowMiles": $(".include-lowmiles").is(":checked"),
            "HasPowerWindows": $(".include-powerwindows").is(":checked"),
            "HasNavigation": $(".include-navigation").is(":checked"),
            "HasHeatedSeats": $(".include-heatedseats").is(":checked")
        }
        
        var jqXhr = $.ajax({
            url: "/Home/PostData",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(carOptions),
            });

        jqXhr.done(function (data) {
            if (data && typeof callback === "function") {
                data;
            }
        });

        jqXhr.fail(function (xhr, textStatus, errorThrown) {
            console.log({ "textStatus": textStatus, "errorThrown": errorThrown, "xhr": xhr });
        });
    }

    function bindEventListeners() {
        var $contentWrapper = $(".cardealership-listing-container");

        $contentWrapper.on("click", ".cb-filter-selection", fetchData);
    }


    function init() {
        bindEventListeners();
    }

    $(function () {
        init();
    });

})(jQuery, window, document);
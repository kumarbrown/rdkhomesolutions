/// <reference path="../typings/jquery/jquery.d.ts" />
/// <reference path="../typings/toastr/toastr.d.ts" />
var NewsLetter = /** @class */ (function () {
    function NewsLetter() {
        var _this = this;
        var newsLetterSubscribeButton = document.getElementById("newsLetterSubscribeButton");
        newsLetterSubscribeButton.addEventListener("click", function (e) { return _this.subscribe(e); });
    }
    NewsLetter.prototype.subscribe = function (e) {
        e.preventDefault();
        var emailAddress = $('#newsLetterSubscribeEmailAddress').val();
        $.ajax({
            type: 'POST',
            url: '/NewsLetter/Subscribe/',
            data: JSON.stringify({ email: emailAddress }),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (result) {
                if (result.success) {
                    toastr.success('Thank you for subscribing to our news letter!', 'Success');
                }
                else {
                    toastr.error(result.message, 'Inconceivable!');
                }
            },
            error: function () {
                toastr.error('An error occurred processing your request.', 'Error');
            }
        });
    };
    return NewsLetter;
}());
var newsLetter = new NewsLetter();
//# sourceMappingURL=newsLetter.js.map
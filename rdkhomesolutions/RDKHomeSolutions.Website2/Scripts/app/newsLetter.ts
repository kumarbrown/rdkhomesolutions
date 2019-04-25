/// <reference path="../typings/jquery/jquery.d.ts" />
/// <reference path="../typings/toastr/toastr.d.ts" />

interface NewsLetterSubscribeResult {
    result: boolean;
    message: string;
}

class NewsLetter {
    constructor() {
        let newsLetterSubscribeButton = document.getElementById("newsLetterSubscribeButton");
        newsLetterSubscribeButton.addEventListener("click", (e: Event) => this.subscribe(e));
    }
    subscribe(e: Event) {
        e.preventDefault();
        let emailAddress = $('#newsLetterSubscribeEmailAddress').val();
        $.ajax({
            type: 'POST',
            url: '/NewsLetter/Subscribe/',
            data: JSON.stringify({ email: emailAddress }),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: (newsLetterSubscribeResult: NewsLetterSubscribeResult) => {
                if (newsLetterSubscribeResult.result) {
                    toastr.success('Thank you for subscribing to our news letter!', 'Success');
                } else {
                    toastr.error(newsLetterSubscribeResult.message, 'Error');
                }
            },
            error: () => {
                toastr.error('An error occurred processing your request.', 'Error');
            }
        });
    }
}

let newsLetter = new NewsLetter();
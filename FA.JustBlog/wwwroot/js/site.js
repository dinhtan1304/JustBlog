/*!
* Start Bootstrap - Clean Blog v6.0.9 (https://startbootstrap.com/theme/clean-blog)
* Copyright 2013-2023 Start Bootstrap
* Licensed under MIT (https://github.com/StartBootstrap/startbootstrap-clean-blog/blob/master/LICENSE)
*/
window.addEventListener('DOMContentLoaded', () => {
    let scrollPos = 0;
    const mainNav = document.getElementById('mainNav');
    const headerHeight = mainNav.clientHeight;
    window.addEventListener('scroll', function () {
        const currentTop = document.body.getBoundingClientRect().top * -1;
        if (currentTop < scrollPos) {
            // Scrolling Up
            if (currentTop > 0 && mainNav.classList.contains('is-fixed')) {
                mainNav.classList.add('is-visible');
            } else {
                console.log(123);
                mainNav.classList.remove('is-visible', 'is-fixed');
            }
        } else {
            // Scrolling Down
            mainNav.classList.remove(['is-visible']);
            if (currentTop > headerHeight && !mainNav.classList.contains('is-fixed')) {
                mainNav.classList.add('is-fixed');
            }
        }
        scrollPos = currentTop;
    });
})

function customTimeAgo(date) {
    const now = new Date();
    const postedOn = new Date(date);
    const diff = Math.floor((now - postedOn) / 1000); // Time difference in seconds

    if (diff < 60) {
        return "vừa mới";
    } else if (diff < 3600) {
        const minutes = Math.floor(diff / 60);
        return minutes + " minutes ago";
    } else if (diff < 86400) {
        const options = { hour: "numeric", minute: "numeric" };
        return "yesterday at " + postedOn.toLocaleString("en-US", options);
    } else {
        const options = { month: "2-digit", day: "2-digit", year: "numeric", hour: "numeric", minute: "numeric" };
        return postedOn.toLocaleString("en-US", options);
    }
}

// Get all elements with the "post-meta" class and update their text with the custom time ago value
const postMetas = document.getElementsByClassName("post-meta");
for (let i = 0; i < postMetas.length; i++) {
    const postedOn = postMetas[i].querySelector("#postedOn").textContent;
    const customPostedOn = customTimeAgo(postedOn);
    postMetas[i].innerHTML = postMetas[i].innerHTML.replace(postedOn, customPostedOn);
}

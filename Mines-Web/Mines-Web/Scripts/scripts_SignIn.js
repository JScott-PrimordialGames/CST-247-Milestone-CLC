const btns_SwitchForms = document.querySelectorAll(".switch-form-button");
const slide_container = document.querySelector(".slide-container");


btns_SwitchForms.forEach((item) =>
    item.addEventListener("click", () => {
        slide_container.classList.toggle("slide");
    })
);
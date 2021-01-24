const cells = document.querySelectorAll(".cell-button");

cells.forEach((cell) =>
    cell.addEventListener("contextmenu", () => {
        cell.classList.toggle("flagged");
    })
);
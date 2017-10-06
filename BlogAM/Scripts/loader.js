window.addEventListener('load', () => {
    const loader = document.querySelector('.loader')
    loader.classList += " on"

    setTimeout(() => {
        loader.classList = "loader"
        document.body.style.overflowY = ""
    }, 3500)
})
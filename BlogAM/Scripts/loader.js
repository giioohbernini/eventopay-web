window.addEventListener('load', () => {
    const loader = document.querySelector('.loader')
    loader.classList += " on"

    setTimeout(() => {
        loader.classList = "loader"
    }, 3500)
})
// var userLang = navigator.language || navigator.userLanguage; 
// alert ("The language is: " + userLang);

// alert (Intl.DateTimeFormat().resolvedOptions().locale);

let mylanguage;
myLanguage = new Language("Título", "SubTítulo", "Primera del Index", "Segunda del Index", "Primera del Menú", "Segunda del menú", "Primera del Footer", "Segunda del Footer");

function getLanguages() {
    const langs = navigator.languages;
    const result = document.getElementById('result');
    result.innerHTML += `The Preferred languages are: <b>${langs}</b>`;
}

function language(language) // Una Vez Cargado el DOM, se encuentran las ID de los Elementos sin Necesidad de Usar document.getElementById("element");.
{
    // switch (element.innerHTML)
    switch (language)
    {
        // case "Español": // Con element.innerHTML Obtiene el Contenido del Elemento.
        case "spanish": // Con element.id Obtiene el nombre de la ID del Elemento.
            myLanguage = new Language("Título", "Subtítulo", "Primera del Index", "Segunda del Index", "Primera del Menú", "Segunda del menú", "Primera del Footer", "Segunda del Footer");
            break;
        // case "English":
        case "english":
            myLanguage = new Language("Title", "Subtitle", "Index First", "Index Second", "Menu First", "Menu Second", "Footer First", "Footer Second");
            break;
        case "portuguese":
            myLanguage = new Language("Título", "Subtítulo", "Primeiro do Index", "Segundo do Index", "Primeiro do Menu", "Segundo do Menu", "Primeiro do Footer", "Segundo do Footer");
            break;
        case "german":
            myLanguage = new Language("Titel", "Untertitel", "Erster des Index", "Zweiter des Index", "Zuerst das Menü", "Zweiter im Menü", "Fußzeile zuerst", "Zweite Fußzeile");
            break;
        case "chinese":
            myLanguage = new Language("資質", "標題", "指數第一名", "指數第二位", "菜單第一個", "菜單第二項", "頁尾優先", "第二個頁腳");
            break;
    }
    // document.getElementById("title").innerHTML = myLanguage.title;
    // document.getElementById("html_title").innerHTML = myLanguage.title;
    // document.getElementById("subtitle").innerHTML = myLanguage.subtitle;
    // document.getElementById("footer_first").innerHTML = myLanguage.footer_first;
    // document.getElementById("footer_second").innerHTML = myLanguage.footer_second;

    title.innerHTML = myLanguage.title;
    html_title.innerHTML = myLanguage.title;
    subtitle.innerHTML = myLanguage.subtitle;
    footer_first.innerHTML = myLanguage.footer_first;
    footer_second.innerHTML = myLanguage.footer_second;
}
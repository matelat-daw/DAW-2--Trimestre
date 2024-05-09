function totNumPages() // Función para la paginación
{
    return Math.ceil(window.length / window.qtty); // Calcula la cantidad de páginas que habrá, divide la cantidad de datos por 5 resultados a mostrar por página.
}

function prev() // Función para ir a la página anterior.
{
    if (window.page > 1) // Si la página actual es mayor que la página 1.
    {
        window.page--; // Decrementa la variable page, página anterior.
        change(window.page, window.qtty); // Llama a la función change pasandole el número de página a mostrar y la cantidad de datos a mostrar que siempre es 5.
    }
}

function next() // La Función next muestra la página siguiente.
{   
    if (window.page < totNumPages()) // Si la página en la que estoy es menor que la última.
    {
        window.page++; // Incremento la página
        change(window.page, window.qtty); // Llamo a la función que muestra los resultados.
    }
}

function change(page, qtty) // Función que muestra los resultados de a 5 en la tabla, recibe la página page, la cantidad de resultados a mostrar qtty y true si viene de index y false si viene de profile.
{
    window.page = page; // Asigno la variable page, a la variable global window.page.
    window.qtty = qtty; // Asigno la variable qtty, a la variable global window.qtty.
    const tags = array_key.length - 1; // Cantidad de Datos en Cada Tupla de Valores.
    var length = array_value.length / (tags + 1); // Obtengo en length el Tamaño de Cada Tupla en el Array de Valores.
    window.length = length; // Hago global la variable length.

    var html = "<table><tr class='text-center'><th>IP</th><th>MAC</th><th>Host</th><th>Puerto Local</th><th>Puerto Remoto</th><th>Protocolo</th><th>OUI</th><th>Tamaño del Paquete</th><th>Marca</th><th>Fecha</th></tr>";
    for (i = (page - 1) * qtty; i < page * qtty; i++) // Aquí hago el bucle desde la página donde esté, a la cantidad de resultados a mostrar.
    {
        if (i < length) // Si i es menor que el tamaño del array.
        {
            html += "<tr><td>" + array_value[i + (tags * i)] + "</td><td>" + array_value[i + 1 + (tags * i)] + "</td><td>" + array_value[i + 2 + (tags * i)] + "</td><td>" + array_value[i + 3 + (tags * i)] + "</td><td>" + array_value[i + 4 + (tags * i)] + "</td><td>" + array_value[i + 5 + (tags * i)] + "</td><td>" + array_value[i + 6 + (tags * i)] + "</td><td>" + array_value[i + 8 + (tags * i)] + "</td><td>" + array_value[i + 9 + (tags * i)] + "</td><td>" + array_value[i + 7 + (tags * i)] + "</td></tr>";
        }
    }
    html += "</table>";
    table.innerHTML = html; // Muestro todo en pantalla.

    if (length > 5) // Si la cantidad de Artículos es mayor que 5.
    {
        pages.innerHTML = "Página: " + page; // Muestro el número de página.
        if (page == 1) // Si la página es la número 1
        {
            prev_btn.style.visibility = "hidden"; // Escondo el Botón con id prev que mostraría los resultados anteriores.
        }
        else // Si no, estoy en otra página.
        {
            prev_btn.style.visibility = "visible"; // Hago visible el botón para mostrar los resultados anteriores.
        }
        if (page == totNumPages()) // Si estoy en la última página.
        {
            next_btn.style.visibility = "hidden"; // Escondo el botón para mostrar los resultados siguientes.
        }
        else // Si no, estoy en una página intermedia o en la primera.
        {
            next_btn.style.visibility = "visible"; // Hago visible el botón para mostrar los resultados siguientes.
        }
    }
}

/* function wait() // Se muestra una alerta para indicar que verificar la IP demora unos 10 segundos.
{
    alert("Verificar la IP demora unos segundos.\nHaz Click en Aceptar y Se Cargará una Nueva Página Después de Aproximadamente 10 Segundos.");
} */

function addColon()
{
    mac.addEventListener("keydown", (e) => {
        if (e.keyCode != 8)
        {
            switch(mac.value.length)
            {
                case 2:
                case 5:
                case 8:
                case 11:
                case 14:
                    mac.value += ":";
                    break;
            }
        }
    });
}

function drawBasic() // Gráfica de Barras.
{
    let values = [];

    values = getValues(); /// Llama a la función que obtiene los valores de InfluxDB.

    // values = {"cols":[
    //     {"id":"","label":"Month","pattern":"","type":"string"},
    //     {"id":"","label":"Sales","pattern":"","type":"number"},
    //     {"id":"","label":"","pattern":"","type":"number","p":{"role":"interval"}},
    //     {"id":"","label":"","pattern":"","type":"number","p":{"role":"interval"}},
    //     {"id":"","label":"Expenses","pattern":"","type":"number"}],
    //   "rows":[
    //     {"c":[
    //       {"v":"April","f":null},
    //       {"v":1000,"f":null},
    //       {"v":900,"f":null},
    //       {"v":1100,"f":null},
    //       {"v":400,"f":null}]},
    //     {"c":[
    //       {"v":"May","f":null},
    //       {"v":1170,"f":null},
    //       {"v":1000,"f":null},
    //       {"v":1200,"f":null},
    //       {"v":460,"f":null}]},
    //     {"c":[{"v":"June","f":null},
    //       {"v":660,"f":null},
    //       {"v":550,"f":null},
    //       {"v":800,"f":null},
    //       {"v":1120,"f":null}]},
    //     {"c":[
    //       {"v":"July","f":null},
    //       {"v":1030,"f":null},
    //       {"v":null,"f":null},
    //       {"v":null,"f":null},
    //       {"v":540,"f":null}]}],
    //   "p":null
    //   };

    // var data = new google.visualization.DataTable(values);

//     var data = new google.visualization.DataTable();
//     data.addColumn('string', 'MAC');
//     data.addColumn('string', 'Time');
//     data.addColumn('number', 'Size');
//     data.addColumn('number', 'Amount');

// for (var i = 0; i < values.length; i++)
// {
//     data.addRow([values[i].mac, values[i].time, values[i].size, values[i].amount]);
// }


var data = google.visualization.arrayToDataTable(values);

var options = {
    title: 'Ataques Totales',
    hAxis: {
        title: 'Ataques de Mayor a Menor, Por Cantidad y por Tamaño de Paquete',
        format: 'H:mm a',
        viewWindow: {
        min: [0, 0, 0],
        max: [24, 0, 0]
        }
    },
    vAxis: {
        title: 'Rating (Escala 1:10)'
    }
};

    new google.visualization.ColumnChart(chart_div).draw(data, options);
}

function drawChart() // Gráfica de Anillo.
{
    let values = [];
    values = getValues();

    var data = google.visualization.arrayToDataTable(values);

    var options = {
        title: 'Ataques Totales',
        pieHole: 0.4,
        slices: {}
    };
      
    var color = 30;
    for(var i = 0; i < values.length; i++)
    {
        options.slices[i] = {color: "rgb(255," + color + "," + color + ")"};
        color+=Math.round(256/values.length)-1;
    }
    
    new google.visualization.PieChart(donutchart).draw(data, options);
}

function getValues()
{
    let values = [];
    let sizes = [];

    // sizes.push({size: 'Size', amount: 'Amount', mac: 'MAC', time: 'Time'});

    for(i = 0; i < length; i++){
        if(!sizes.map(e => e.size).includes(array_value[i + 8 + (i * 9)]))
            sizes.push({size: array_value[i + 8 + (i * 9)], amount: 1, mac: array_value[i + 1 + (i * 9)], time: array_value[i + 7 + (i * 9)]});
            // sizes.push({size: array_value[i + 8 + (i * 9)], amount: 1});
        else
            sizes[sizes.map(e => e.size).indexOf(array_value[i + 8 + (i * 9)])].amount++;
    }

    sizes.sort(function (a, b)
    {
        return b.amount - a.amount || b.size - a.size;
    });

    // values.push(['Size', 'Amount']);

    values.push(['Size', 'Amount', 'MAC', 'Time']);

    for (i = 0; i < sizes.length; i++)
    {
        // values[i] = [sizes[i].size, sizes[i].amount];
        values.push([sizes[i].size, sizes[i].amount, parseInt('sizes[i].mac'), parseInt('sizes[i].time')]);
        console.log("El contenido de Values en size es: " + values[i + 1]);
    }

    // values.unshift(['Size', 'Amount']);

    return values;
    // return sizes;
}

function toast(warn, ttl, msg) // Función para mostrar el Diálogo con los mensajes de alerta, recibe, Código, Título y Mensaje.
{
    if (warn == 1) // Si el código es 1, es una alerta.
    {
        title.style.backgroundColor = "#000000"; // Pongo los atributos, color de fondo negro.
        title.style.color = "yellow"; // Y color del texto amarillo.
    }
    else if (warn == 0) // Si no, si el código es 0 es un mensaje satisfactorio.
    {
        title.style.backgroundColor = "#FFFFFF"; // Pongo los atributos, color de fondo blanco.
        title.style.color = "blue"; // Y el color del texto azul.
    }
    else // Si no, viene un 2, es una alerta de error.
    {
        title.style.backgroundColor = "#000000"; // Pongo los atributos, color de fondo negro.
        title.style.color = "red"; // Y color del texto rojo.
    }
    title.innerHTML = ttl; // Muestro el Título del dialogo.
    message.innerHTML = msg; // Muestro los mensajes en el diálogo.
    alerta.click(); // Lo hago aparecer pulsando el botón con ID alerta.
}

function screenSize() // Función para dar el tamaño máximo de la pantalla a las vistas.
{
    let view4 = document.getElementById("view4");
    let height = window.innerHeight; // window.innerHeight es el tamaño vertical de la pantalla.

    if (view1.offsetHeight < height) // Si el tamaño vertical de la vista es menor que el tamaño vertical de la pantalla.
    {
        view1.style.height = height + "px"; // Asigna a la vista el tamaño vertical de la pantalla.
    }

    if (view2 != null) // Si existe el div view2
    {
        if (view2.offsetHeight < height)
        {
            view2.style.height = height + "px";
        }
        if (view3 != null)
        {
            if (view3.offsetHeight < height)
            {
                view3.style.height = height + "px";
            }
            if (view4 != null)
            {
                if (view4.offsetHeight < height)
                {
                    view4.style.height = height + "px";
                }
            }
            
        }
    }
}

function verify() // Función para validar las contraseñas de registro de alumnos y las de modificación.
{
    if (pass1.value != pass2.value) // Verifico si los valores en los input pass y pass2 no coinciden.
    {
        toast(1, "Hay un Error", "Las contraseñas no coinciden, has escrito: " + pass1.value + " y " + pass2.value); // Si no coinciden muestro error.
        return false; // Devuelvo false, el formulario no se envía.
    }
    else // Si son iguales.
    {
        return true; // Devuelvo true, envía el formulario.
    }
}

function showEye(which) // Función para mostrar el ojo de los input de las contraseñas, recibe el número del elemento que contiene el ojo.
{
    let eye = document.getElementById("togglePassword" + which); // Asigno a eye la id del elemento que contiene el ojo.
    eye.style.visibility = "visible"; // Hago visible el elemento, el ojo.
}

function spy(which) // Función para el ojito de las Contraseñas al hacer click en el ojito, recibe el número de la ID del input de la password.
{
    const togglePassword = document.querySelector('#togglePassword' + which); // Asigno a la constante togglePassword el input con ID togglePassword + which.
    const password = document.querySelector('#pass' + which); // Asigno a password la ID del input con ID pass + which.
    
    const type = password.getAttribute('type') === 'password' ? 'text' : 'password'; // Asigno a type el resultado de un operador ternario, si presiono el ojito y el tipo del input es password
    // lo cambia a text, si es text lo cambia a password.
    password.setAttribute('type', type); // Le asigno el atributo al input password.
    togglePassword.classList.toggle('fa-eye-slash'); // Cambia el aspecto del ojito, al cambiar el input a tipo texto, el ojo aparece con una raya.
}

function showImg(src) // Not in Use but a Good One
{
    var alertaImg = document.getElementById("alertaImg"); // La ID del botón del dialogo.
    var img = document.getElementById("show_pic"); // Asigno a la variable title el h4 con id title.
        
    img.src = src; // Muestro los mensajes en el diálogo.
    alertaImg.click(); // Lo hago aparecer pulsando el botón con ID alerta.
}

function changeit() // Función para la página de contacto.
{
    // var changes = document.getElementById("changes"); // En la variable button obtengo la ID del input type submit change.

    if (contact.value != "") // Si el valor en el selector ha cambiado.
    {
        switch (contact.value) // Hago un switch al valor en el selector.
        {
            case "Teléfono":
                email.style.visibility = "hidden";
                phone.style.visibility = "visible";
                em.required = false;
                ph.required = true;
                changes.value = "Llamame!";
                break;
            case "Whatsapp":
                email.style.visibility = "hidden";
                phone.style.visibility = "visible";
                em.required = false;
                ph.required = true;
                changes.value = "Mandame un Guasap";
                break;
            default:
                email.style.visibility = "visible";
                phone.style.visibility = "hidden";
                ph.required = false;
                ph.value = 1;
                em.required = true;
                changes.value = "Espero tu E-mail";
                break;
        }
    }
}

function connect(how)
{
    let mssg = document.getElementById('mssg').value;
    let num = 664774821;
    var win = window.open('https://wa.me/' + num + '?text=Por Favor contactame por: ' + how + ' al: ' + mssg + ' Mi nombre es: ', '_blank');
}

function screen() // Esta función comprueba si el ancho de la pantalla es de Ordenador o de Teléfono.
{
    let width = innerWidth;
    if (width < 965) // Si el ancho es inferior a 965.
    {
        pc.style.visibility = "hidden"; // Oculta el menú de Ordenador
        mobile.style.visibility = "visible"; // Muestra el menú de Teléfono.
    }
    else // Si es mayor o igual a 965;
    {
        pc.style.visibility = "visible"; // Muestra el menú para Ordenador
        mobile.style.visibility = "hidden"; // Oculta el menú para Teléfono.
    }
}

function goThere() // Cuando cambia el selector del menú para Teléfono.
{
    var change = document.getElementById("change").value; // Change obtiene el valor en el selector.
    switch(change)
    {
        case "contact":
            window.open("contact.php", "_blank");
        break;
        case "request":
            window.open("request.php", "_self");
        break;
        case "profile" :
            window.open("profile.php", "_self");
        break;
        case "view3" :
            window.open("index.php#view3", "_self");
        break;
        case "view2" :
            window.open("index.php#view2", "_self");
        break;
        default :
            window.open("index.php#view1", "_self");
        break;
    }
}

function printIt(number)
{
    if (number != -1) // Si el numero que llega es distinto de -1.
    {
        var img = document.getElementById("img" + number); // Asigno a la variable img la ID del elemento img + numero de factura.
    }
    else // Si llega -1.
    {
        var img = document.getElementById("img0"); // Estoy viedo la última factura, es la imagen 0, Asigno a la variable img la ID del elemento img0.
    }
    const src = img.src; // Asigno a la constante src la imagen.
    const win = window.open(''); // Asigno a la constante win una nueva ventana abierta.
    win.document.write('<img src="' + src + '" onload="window.print(); window.close();">'); // Escribo en la ventana abierta un elemento img con la imagen a imprimir y la envía a la impresora y al terminar cierra la ventana.
}

function capture(number)
{
    const print = document.getElementById("printable" + number); // Asigna a print el Div con ID printable + number
    const image = document.getElementById("image" + number); // Asigna a image el Div con ID image + number, contendrá el elemento img con la factura.

    html2canvas(print).then((canvas) => {
        const base64image = canvas.toDataURL('image/png'); // genera la imagen base64image a partir del contenido de print, el div que contiene la factura.
        image.setAttribute("href", base64image);
        const img = document.createElement("img");
        img.id = "img" + number;
        img.src = base64image;
        img.alt = "Factura: " + number;
        print.remove();
        image.appendChild(img);
    });
}

function pdfDown(number)
{
    const image = document.getElementById("img" + number); // Div con ID printable0, contiene la factura.

    var doc = new jsPDF();
    doc.addImage(image, 'png', 10, 10, 240, 60, '', 'FAST');
    doc.save();
}

function givemeData(oui)
{
    alert("los datos de esta MAC son: " + oui);
}

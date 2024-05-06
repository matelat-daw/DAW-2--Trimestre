<?php
    //check for new messages.

    echo "<h1>Verifica los Mensajes IMAP de Gmail</h1>";

    $mailbox = imap_open("{imap.gmail.com:993/imap/ssl/novalidate-cert}INBOX", "matelat@gmail.com", $_ENV["Gmail-matelat"]);

    // Check messages.
    $check = imap_check($mailbox);
    $today = "";
    $date = $check->Date; // Fecha del Últmo Mensaje.
    $qtty = $check->Nmsgs; // Cantidad Total de Mansajes en la Bandeja de Entrada.
    $temp = explode(" ", $date);
    for ($i = 0; $i < 4; $i++) // Bucle hasta 4 para obtener los 4 primeros datos del Array $temp, Nombre del Día, Día, Mes, Año.
    {
        $today .= $temp[$i]; // Concateno la Fecha en la Variable $today.
    }
    echo "<h3>$today</h3>
    <pre>
    Fecha de los Mensajes Más Recientes : $check->Date
    <br></pre>";
    /* print("Connection type : " . $check->Driver);
    print("<BR>");
    print("Name of the mailbox : " . $check->Mailbox);
    print("<BR>");
    print("Number of messages : " . $check->Nmsgs);
    print("<BR>");
    print("Number of recent messages : " . $check->Recent);
    print("<BR>");
    print("</PRE>"); */

    // show headers for messages.

    while ($qtty > 0) // Mientras la Cantiad de Mensajes Sea Mayor que 0.
    {
        $header = imap_headerinfo($mailbox, $qtty); // Obtiene la Información de Todos los Mensajes.
        $mail_today = "";
        $mail_date = $header->Date; // Fecha de los Mensajes.
        $mail_temp = explode(" ", $mail_date);
        for ($i = 0; $i < 4; $i++)
        {
            $mail_today .= $mail_temp[$i];
        }
        if ($today == $mail_today) // Si los Mensajes son de Hoy, $today = a los Mensajes del Día.
        {
            echo "<pre>Fecha del Mansaje : $header->Date<br>
            Asunto del Mensaje : $header->Subject<br></pre>"; // Muestro la Fecha y el Asunto del Mensaje.
            /* print("Header To : " . $header->to) . "<BR>
            Header From : " . $header->From . "<BR>
            Header cc : " . $header->cc . "<BR>
            Header ReplyTo : " . $header->ReplyTo . "<BR>"); */

            /* print("<PRE>"
            imap_body($mailbox, $qtty)) // Muestra el Contenido del Mensaje.
            "</PRE><HR>"); */
        }
        else
        {
            $qtty = 1;
        }
        $qtty--; // Decremento la Cantidad de Mensajes.
    }

    imap_close($mailbox);
?>
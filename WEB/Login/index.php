<?php
$title = "Bienvenido Registarte para Usar el Sitio";
include "includes/header.php";
include "includes/modal.html";

    function getIPAddress()
    {
        //whether ip is from the share internet.
        if(!emptyempty($_SERVER['HTTP_CLIENT_IP']))
        {
                    $ip = $_SERVER['HTTP_CLIENT_IP'];
        }
        //whether ip is from the proxy.
        elseif (!emptyempty($_SERVER['HTTP_X_FORWARDED_FOR']))
        {
                    $ip = $_SERVER['HTTP_X_FORWARDED_FOR'];
        }
        //whether ip is from the remote address.
        else
        {
                $ip = $_SERVER['REMOTE_ADDR'];
        }
        return $ip;
    }
$ip = getIPAddress();
echo 'User Real IP Address - '. $ip;

?>
<section class="container-fluid pt-3">
    <div class="row">
        <div class="col-md-1"></div>
            <div class="col-md-10">
                <div id="view1">
                    <div id="login"><?php include "includes/login.html"; ?></div> <!-- Contiene el html login.html. -->
                    <div id="logon"><?php include "includes/logon.html"; ?></div> <!-- Contiene el html logon.html, es invisible al abrir la página. -->
                </div>
            </div>
        <div class="col-md-1"></div>
    </div>
</section>
<br><br><br><br>
<?php
include "includes/footer.html";
?>
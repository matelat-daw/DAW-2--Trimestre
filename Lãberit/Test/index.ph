<?php
include "vendor/autoload.php";

$hosts = Nmap\Nmap::create()->scan([ '192.168.0.217' ]);

$ports = $hosts->getOpenPorts();

echo $ports;
?>
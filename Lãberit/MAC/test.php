<?php
exec('rustscan -a 192.168.0.217 > data.txt', $result);
print_r ($result);

exec('nmap 192.168.0.217 > data2.txt', $result2);
print_r ($result2);
?>
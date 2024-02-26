<?php
class user
{
    private $dni;
    private $name;
    private $surname1;
    private $surname2;
    private $phone;
    private $email;

    function __construct($dni, $name, $surname1, $surname2, $phone, $email)
    {
        $this->dni = $dni;
        $this->name = $name;
        $this->surname1 = $surname1;
        $this->surname2 = $surname2;
        $this->phone = $phone;
        $this->email = $email;
    }

    function getDni()
    {
        return $this->dni;
    }

    function getName()
    {
        return $this->name;
    }

    function getSurname1()
    {
        return $this->surname1;
    }

    function getSurname2()
    {
        return $this->surname2;
    }

    function getPhone()
    {
        return $this->phone;
    }

    function getEmail()
    {
        return $this->email;
    }
}
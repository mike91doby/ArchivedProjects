<?php
$dsn = "mysql:host=localhost;dbname=db001264912";
$username = "db001264912";
$password = "PASSWORD";
try {
    $db = new PDO($dsn, $username, $password);
    //echo "Connected!";
} catch (PDOException $e) {
    /* This code will potentially give away too much information.
    $error_message = $e->getMessage();
    echo $error_message;*/
    exit("<br />Error connecting to the database");
}
?>

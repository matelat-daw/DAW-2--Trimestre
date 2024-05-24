<?php
// $time = date("U",strtotime('2024-05-06T15:40:34Z'));
// echo $time;

echo '<script>
    let array = [];
    array = [{length: 10, qtty: 3}, {length: 20, qtty: 1}, {length: 30, qtty: 1}, {length: 25, qtty: 2}, {length: 15, qtty: 1}];

    array.sort(function (a, b)
    {
        return b.qtty - a.qtty || b.length - a.length;
    });

    let data = [];
    for (i = 0; i < array.length; i++)
    {
        data[i] = [array[i].length, array[i].qtty];
    }

    console.log("Los Datos Ahora son: " + data);

</script>';
?>
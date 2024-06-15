let imgs = ["img/img1.jpg", "img/img2.jpg", "img/img3.jpg", "img/img4.jpg", "img/img5.jpg"];

function show()
{
    var radio = [];
    img.src = imgs[0];
    for (var i = 0; i < imgs.length; i++)
    {
        radio[i] = document.createElement("input");
        radio[i].id = "radio" + i;
        radio[i].name = "img";
        radio[i].type = "radio";
        radio[i].onclick = function(){ change(this.id) };
        container.appendChild(radio[i]);
    }
    radio0.checked = true;
}

function change(id)
{
    let result = id.slice(5);
    img.src = imgs[result];
}
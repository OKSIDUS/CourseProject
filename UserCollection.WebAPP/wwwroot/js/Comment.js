//const { variationPlacements } = require("@popperjs/core");

const connection = new signalR.HubConnectionBuilder()
    .withUrl("/commentHub")
    .build();

//connection.start().catch(err => console.error(err.toString()));

connection.start().then(function () {
    console.log("SignalR Connected!");
}).catch(function (err) {
    return console.error(err.toString());
});

connection.on("ReceiveComment", (username, comment) => {
    var li = document.createElement("li");
    li.classList.add("list-group-item");

    var div1 = document.createElement("div");
    div1.classList.add("d-flex", "w-100", "justify-content-between");

    var strong = document.createElement("strong");
    strong.textContent = username;

    var span = document.createElement("span");
    span.classList.add("badge", "badge-primary");
    span.textContent = comment;

    var div2 = document.createElement("div");
    div2.textContent = comment;

    div1.appendChild(strong);
    div1.appendChild(span);

    li.appendChild(div1);
    li.appendChild(div2);

    document.getElementById("messagesList").appendChild(li);

})

var id = document.getElementById("id");
var addCommentForm = document.getElementById("SendButton" + id);
document.getElementById("SendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("commentText").value;
    var form = document.getElementById("addCommentForm");
    form.submit();
    connection.invoke("SendComment", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();

    
});
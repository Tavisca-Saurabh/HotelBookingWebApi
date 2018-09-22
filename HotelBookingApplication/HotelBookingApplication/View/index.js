/***************************************Hotel*****************/
var GetAllHotels = () => {
    HotelAllAjaxCall();
}

var HotelAllAjaxCall = () => {
    var server = "/get";
    $.ajax({
        url: server,
        type: 'GET',
        contentType: 'application/json',
        dataType: 'json',
        success: function (result) {
            console.log("success");
            console.log(result);
        },
        error: function (reason) {
            console.log("had a failure");
            console.log(reason);
        }
    }).done((response) => {

        if ($('#hotelsDiv').is(':empty')) {
            //$("#hotelsDiv").append("<div>" + response + "</div>");
            response.forEach((hotel) => {
                var SaveId = "Save" + hotel.ID;
                var iDiv = document.createElement('div');
                iDiv.className = 'hotel-list';
                var imageDiv = document.createElement('div');
                imageDiv.className = 'image-holder';
                var imageTag = document.createElement('img');
                imageTag.className = 'hotel-image';
                imageTag.src = "Images/Hotels/" + hotel.image + "";
                imageDiv.appendChild(imageTag);
                iDiv.appendChild(imageDiv);

                var descriptionDiv = document.createElement('div');
                descriptionDiv.className = 'description';
                var nameSpan = document.createElement('span');
                nameSpan.className = 'hotel-name';
                nameSpan.innerHTML = hotel.Name;
                descriptionDiv.appendChild(nameSpan);
                var addressSpan = document.createElement('span');
                addressSpan.innerHTML = hotel.Address;
                descriptionDiv.appendChild(addressSpan);
                iDiv.appendChild(descriptionDiv);
                var bookDiv = document.createElement('div');
                bookDiv.className = 'book';

                var button = document.createElement('button');
                button.id = hotel.ID;
                button.innerHTML = "Book Now";
                //button.onclick = BookAjaxCall(hotel.ID);
                bookDiv.appendChild(button);
                iDiv.appendChild(bookDiv);

                $('#hotelsDiv').append(iDiv);
                document.getElementById(hotel.ID).addEventListener("click", () => {
                    BookAjaxCall(hotel.ID);
                });

                //<div class="hotel-list">
                //    <div class="image-holder"><img class="hotel-image" src="Images/Hotels/<%= logo %>" /></div>
                //    <div class="description">
                //        <span class="hotel-name"> <%= name%></span>
                //        <span><%=address %></span>
                //    </div>
                //    <div class="book">
                //        <button class="<%= _id %>">Book Now</button>
                //        <span><%= startDate1 %> <%= endDate1 %></span>
                //    </div>
                //</div>
            });
        }
    });
};
var BookAjaxCall = (id) => {
    alert(id);
    var server;
    server = "/get/" + id;
    $.ajax({
        url: server,
        type: 'GET',
        contentType: 'application/json',
        dataType: 'json',
        success: function (result) {
            console.log("success");
            console.log(result);
        },
        error: function (reason) {
            console.log("had a failure");
            console.log(reason);
        }
    }).done((response) => {
        if ($('#hotelbookDiv').is(':empty')) {
            //$("#hotelsDiv").append("<div>" + response + "</div>");
            response.forEach((hotel) => {
                var SaveId = "Save" + hotel.ID;
                var iDiv = document.createElement('div');
                iDiv.className = 'hotel-list';
                var imageDiv = document.createElement('div');
                imageDiv.className = 'image-holder';
                var imageTag = document.createElement('img');
                imageTag.className = 'hotel-image';
                imageTag.src = "Images/Hotels/" + hotel.image + "";
                imageDiv.appendChild(imageTag);
                iDiv.appendChild(imageDiv);
                var descriptionDiv = document.createElement('div');
                descriptionDiv.className = 'description';
                var nameSpan = document.createElement('span');
                nameSpan.className = 'hotel-name';
                nameSpan.innerHTML = "Room Type: " + hotel.roomType;
                descriptionDiv.appendChild(nameSpan);
                var addressSpan = document.createElement('span');
                addressSpan.innerHTML = "Room Available: " + hotel.noOfRoomAvailable;
                descriptionDiv.appendChild(addressSpan);
                var priceSpan = document.createElement('span');
                priceSpan.innerHTML = "Price: " + hotel.price;
                descriptionDiv.appendChild(priceSpan);
                iDiv.appendChild(descriptionDiv);
                var bookDiv = document.createElement('div');
                bookDiv.className = 'book';

                var button = document.createElement('button');
                button.id = hotel.roomType;
                button.innerHTML = "Book Now";
                //button.onclick = BookAjaxCall(hotel.roomType);
                button.addEventListener('click', function () {
                    BookRoomAjaxCall(hotel.roomType);
                })
                bookDiv.appendChild(button);
                iDiv.appendChild(bookDiv);
                $("#hotelsDiv").remove();
                //var elem = document.getElementById("hotelsDiv");
                //elem.parentNode.removeChild(elem);
                $('#hotelbookDiv').append(iDiv);

            });
        }
    });
};




var BookRoomAjaxCall = (product) => {
    alert(product);
    var server;
    server = "/post/" + product;
    $.ajax({
        url: server,
        type: 'POST',
        contentType: 'application/json',
        dataType: 'json',
        success: function (result) {
            console.log("success");
            console.log(result);
        },
        error: function (reason) {
            console.log("had a failure");
            console.log(reason);
        }
    }).done((response) => { alert("Saved Successfully"); });
};
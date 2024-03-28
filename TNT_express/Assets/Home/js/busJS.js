// Clicking any seat
$(".seatNumber").click(
    function () {
        if (!$(this).hasClass("seatUnavailable")) {
            // If selected, unselect it
            if ($(this).hasClass("seatSelected")) {
                var thisId = $(this).attr('id');
                var price = $('#seatsList .' + thisId).val();
                $(this).removeClass("seatSelected");
                $('#seatsList .' + thisId).remove();
                // Calling functions to update checkout total and seat counter.
                refreshCounter();
            }
            else {
                // else, select it
                var thisId = $(this).attr('id');
                var id = thisId.split("_");
               
                // Adding this seat to the list
                //var seatDetails = "Row: " + id[0] + " Seat:" + id[1] + " Price:CA$:" + price;
                //$("#seatsList").append('<li value=' + price + ' class=' + thisId + '>' + seatDetails + "  " + "<button id='remove:" + thisId + "'+ class='btn btn-default btn-sm removeSeat' value='" + price + "'><strong>X</strong></button></li>");
        
                $(this).addClass("seatSelected");
                //$("#seatsList").append('<li value=' + price + ' class=' + thisId + '>@Html.EditorFor(model => model.u_name, new { htmlAttributes = new { placeholder = "Enter User name", @class = "t2 form-control"}})' + "<button id='remove:" + thisId + "'+ class='btn btn-default btn-sm removeSeat' ><strong>X</strong></button></li>");
                $('#checkout-form').append(`
                    <div class="from_seats col-lg-12">
                    <input required class="name-value ase form-control" type="text" placeholder="Name" />
                    <input required class="gender-value ase form-control" type="text" placeholder="Gender" />
                    <input required class="age-value asee form-control" type="number" placeholder="Age" />
                    <input required class="id-value" type="hidden" value="${thisId}"/>
                   </div>
                `)
                addToCheckout(price);
                refreshCounter();
            }
        }
    }
);
// Clicking any of the dynamically-generated X buttons on the list
$(document).on('click', ".removeSeat", function () {
    // Getting the Id of the Seat
    var id = $(this).attr('id').split(":");
    $('#seatsList .' + id[1]).remove();
    $("#" + id[1] + ".seatNumber").removeClass("seatSelected");
}
);
// Function to refresh seats counter
function refreshCounter() {
    $(".seatsAmount").text($(".seatSelected").length);
}

// Clear seats.
$("#btnClear").click(
    function () {
        $('.seatSelected').removeClass('seatSelected');
        $('.name-value').remove();
        $('.from_seats').remove();
    }
);

document.getElementById('checkout-form').onsubmit = (e) => {

    $('.seatSelected').addClass('seatUnavailable')
    e.preventDefault()
}

document.getElementById('btnCheckout').onclick = () => {
    const form = document.getElementById('checkout-form');
    const nameValues = [];
    const ageValues = [];
    const genderValues = [];
    const idValues = [];
    document.querySelectorAll('.name-value').forEach((input) => nameValues.push(input.value))
    document.querySelectorAll('.age-value').forEach((input) => ageValues.push(input.value))
    document.querySelectorAll('.gender-value').forEach((input) => genderValues.push(input.value))
    document.querySelectorAll('.id-value').forEach((input) => idValues.push(input.value))
    const seats = nameValues.map((val, index) => ({ name: val, age: ageValues[index], id: idValues[index], gender: genderValues[index] }));

    for (seat of seats) {
        if (!seat.name || !seat.age || !seat.gender || !seat.id) return;
    }
    const data = {
        busId: form.bus_id.value,
        seats
    }

    console.log(data);
    document.getElementById("hiddenobj").value =JSON.stringify(data);
}
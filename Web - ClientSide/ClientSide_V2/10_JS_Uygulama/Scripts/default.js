var currentPersonId = 1

//JSON Nesnesi :

//var person_v2 = {
//    "Id": 0,
//    "İsim": "",
//    "Soyisim": "",
//    "Telefonlar" : []
//}


//person_v2.Id = "1"
//person_v2.İsim = "Mahmut"
//person_v2.Soyisim = "Tuncer"
//person_v2.Telefonlar.push("32432432")

var Person = function () {
    this.Id = 0
    this.FirstName = ""
    this.LastName = ""
    this.Phones = []
}

var peopleList = []

function AddPhoneBlock(sender) {
    var newPhoneBlock = '<div class="form-inline"> <input class="form-control" type="text" name="Phone" value="" placeholder="Phone..." /> <input type="button" class="btn btn-success" value="+" onclick="AddPhoneBlock(this)"/> <input type="button" class="btn btn-warning" value="-" onclick="RemovePhoneBlock(this)"/></div>'

    var phoneArea = document.getElementById("phone-area")

    //1. Yöntem
    //a
    //phoneArea.innerHTML += newPhoneBlock
    //b
    //sender.parentElement.parentElement.innerHTML += newPhoneBlock

    //2. Yöntem
    //sender.parentElement.outerHTML += newPhoneBlock

    //3. Yöntem
    var yeniElement = document.createElement("div")
    yeniElement.innerHTML = '<input class="form-control" type="text" name="Phone" value="" placeholder="Phone..." /> <input type="button" class="btn btn-success" value="+" onclick="AddPhoneBlock(this)"/> <input type="button" class="btn btn-warning" value="-" onclick="RemovePhoneBlock(this)"/>'
    yeniElement.className = "form-inline"

    sender.parentElement.parentElement.appendChild(yeniElement)
}

function RemovePhoneBlock(sender) {
    sender.parentElement.outerHTML = ""
}

function SavePerson(event) {


    //http://stackoverflow.com/questions/1357118/event-preventdefault-vs-return-false
    //Button elementi submit ise, varsayılan olarak click eventi form içerisindeki inputların değerlerini server'a gönderdiğinden sayfa yenilenir. Bu sebeple submite atanmış bir fonksiyon çalışmaz. Submitin varsayılan bu davranışını engellemek için aşağıdaki kodu yazdık.
    event.preventDefault();

    var newPerson
    var isUpdate = false;

    if (event.target.getAttribute("data-personId")) {
        //data-personId'de değer varsa if kontrolünden geçer ve GÜNCELLEME işlemi yapılması gerekiyor demektir.
        for (var i = 0; i < peopleList.length; i++) {
            if (peopleList[i].Id == event.target.getAttribute("data-personId")) {
                newPerson = peopleList[i];
                isUpdate = true;
                break;
            }
        }
    }
    else {
        //data-personId diye bir attribute yoksa ya da değeri null ise buraya düşer ve YENİ KAYIT işlemi yapılacak demektir.
        newPerson = new Person();
        newPerson.Id = currentPersonId++;
    }



    newPerson.FirstName = document.getElementById("firstName").value

    newPerson.LastName = document.getElementById("lastName").value

    //querySelector func returns first element of selector text
    //(querySelector fonksiyonu selector tanımına uyan ilk elementi döndürür)
    //var phoneInputs = document.querySelector("form input[name=phone]")

    //querySelector func returns all elements of selector text
    //(querySelectorAll fonksiyonu selector tanımına uyan bütün elementleri döndürür)
    var phoneInputs = document.querySelectorAll("form input[name=Phone]")
    newPerson.Phones = []
    for (var i = 0; i < phoneInputs.length; i++) {
        newPerson.Phones.push(phoneInputs[i].value)
    }

    if (!isUpdate) {
        peopleList.push(newPerson)
        ClearForm()
    }
    else {
        //event.target.removeAttribute("data-personId")
        ClearForm(document.querySelector("form .btn-danger"))
    }



    RefreshList();

    SavePeopleToLocalStorage()
}

function ClearForm(cancelButton) {
    //Form içerisindeki inputları temizleyecek

    var formInputs = document.querySelectorAll("form input[type=text]")
    for (var i = 0; i < formInputs.length; i++) {
        formInputs[i].value = ""
    }

    var phoneBlocks = document.querySelectorAll("form .form-inline")
    for (var i = 0; i < phoneBlocks.length; i++) {
        if (phoneBlocks[i].getAttribute("data-osman") != "kalıcı") {
            phoneBlocks[i].remove()
        }
    }

    if (cancelButton) {
        cancelButton.remove()
    }

    document.querySelector("form button").textContent = "Save"
    document.querySelector("form button").removeAttribute("data-personId")
}

function RefreshList() {
    //Tablonun içerisindeki kişi datalarını tekrar yükleyecek


    var table = document.getElementById("people-list")
    table.tBodies[0].innerHTML = ""

    for (var i = 0; i < peopleList.length; i++) {

        var tr = document.createElement("tr")

        //FirstName
        var tdName = document.createElement("td")
        tdName.textContent = peopleList[i].FirstName
        tr.appendChild(tdName)

        //LastName
        var tdSurname = document.createElement("td")
        tdSurname.textContent = peopleList[i].LastName
        tr.appendChild(tdSurname)

        //Phones
        var tdPhones = document.createElement("td")
        for (var j = 0; j < peopleList[i].Phones.length; j++) {
            tdPhones.textContent += peopleList[i].Phones[j] + " | "
        }
        tdPhones.textContent = tdPhones.textContent.substring(0, tdPhones.textContent.length - 3)
        tr.appendChild(tdPhones)

        //# (işlemler)
        var tdOther = document.createElement("td")
        tdOther.innerHTML = "<a href='#' onclick='FillForm({PERSONID}, event)'>Update</a> | <a href='#' onclick='RemovePerson({PERSONID}, event)' >Remove</a>"
                            .replace(/{PERSONID}/gi, peopleList[i].Id)  //regex [EXTRA]
        //.replace("{PERSONID}", peopleList[i].Id)
        tr.appendChild(tdOther)

        table.tBodies[0].appendChild(tr)

    }

}

function FillForm(id, event) {
    ClearForm()

    //http://stackoverflow.com/questions/1357118/event-preventdefault-vs-return-false
    event.preventDefault();

    var person;
    for (var i = 0; i < peopleList.length; i++) {
        if (peopleList[i].Id == id) {
            person = peopleList[i]
            break;
        }
    }

    document.getElementById("firstName").value = person.FirstName
    document.getElementById("lastName").value = person.LastName
    document.querySelector("form input[name=Phone]").value = person.Phones[0]
    if (person.Phones.length > 1) {
        for (var i = 1; i < person.Phones.length; i++) {
            var phoneArea = document.getElementById("phone-area")
            var phoneBlock = document.createElement("div")
            phoneBlock.className = "form-inline"
            phoneBlock.innerHTML = '<input class="form-control" type="text" name="Phone" value="{VALUE}" placeholder="Phone..." /> <input type="button" class="btn btn-success" value="+" onclick="AddPhoneBlock(this)"/> <input type="button" class="btn btn-warning" value="-" onclick="RemovePhoneBlock(this)"/>'
                        .replace("{VALUE}", person.Phones[i])

            phoneArea.appendChild(phoneBlock)
        }
    }

    var saveButton = document.querySelector("form button")
    saveButton.textContent = "Update"

    var cancelButton = document.createElement("button")
    cancelButton.className = "btn btn-danger"
    cancelButton.textContent = "Cancel"
    cancelButton.addEventListener("click", function () {
        ClearForm(this)        //this = cancelButton
    })

    //Birden fazla Cancel butonu eklenmesini önlemek adına bu alttaki koşulu ekledik
    if (document.querySelectorAll("form button").length < 2) {
        saveButton.after(cancelButton)
    }

    saveButton.setAttribute("data-personId", person.Id.toString())

}

function RemovePerson(id, event) {

    event.preventDefault()

    var result = confirm("Are you sure about killing this guys information? :/")

    if (result) {
        for (var i = 0; i < peopleList.length; i++) {
            if (peopleList[i].Id == id) {
                peopleList.splice(i, 1)
                break
            }
        }
    }

    RefreshList()

    SavePeopleToLocalStorage()
}

function SavePeopleToLocalStorage() {
    localStorage.setItem("currentPersonId", currentPersonId)
    localStorage.setItem("peopleList", JSON.stringify(peopleList))
}

function GetPeopleFromLocalStorage() {
    if (localStorage.getItem("peopleList")) {
        var stringJSON = localStorage.getItem("peopleList")
        peopleList = JSON.parse(stringJSON)
    }

    if (localStorage.getItem("currentPersonId")) {
        currentPersonId = parseInt(localStorage.getItem("currentPersonId"))
    }

    RefreshList();
}
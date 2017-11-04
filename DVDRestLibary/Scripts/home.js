$(document).ready(function () {
    $("#divError").hide();
    showForm("#divList");
    loadDirectors();
    loadRaings();
    loadData('', '');
});

function loadDirectors() {
    var optdirA = $('#optDirA');
    var optdirE = $('#optDirE');

    $.ajax({
        type: 'GET',
        url: 'http://localhost:54112/directors',
        success: function (data) {
            var str = '';
            $.each(data, function (index, dir) {
                str += '<option value="' + dir.directorId + '">' + dir.description + '</option>';
            })
            optdirA.append(str);
            optdirE.append(str);
        },
        error: function (xhr, textStatus, errorThrown) {
            showError("#divError", xhr.responseText);
        }
    });
}

function loadRaings() {
    var optRatingA = $('#optRatingA');
    var optRatingE = $('#optRatingE');

    $.ajax({
        type: 'GET',
        url: 'http://localhost:54112/ratings',
        success: function (data) {
            var str = '';
            $.each(data, function (index, rating) {
                str += '<option value="' + rating.ratingId + '">' + rating.description + '</option>';
            })
            optRatingA.append(str);
            optRatingE.append(str);
        },
        error: function (xhr, textStatus, errorThrown) {
            showError("#divError", xhr.responseText);
        }
    });
}

function loadData(SearchCategory, SearchText) {
    clearContentRow();
    var contentRows = $('#contentRows');
    var urlSearch;
    switch (SearchCategory) {
        case "title":
            urlSearch = 'http://localhost:54112/dvds/title/' + SearchText;
            break;
        case "releaseYear":
            urlSearch = 'http://localhost:54112/dvds/year/' + SearchText;
            break;
        case "director":
            urlSearch = 'http://localhost:54112/dvds/director/' + SearchText;
            break;
        case "rating":
            urlSearch = 'http://localhost:54112/dvds/rating/' + SearchText;
            break;
        default:
            urlSearch = 'http://localhost:54112/dvds';        
    }

    $.ajax({
        type: 'GET',
        url: urlSearch,
        success: function (data) {
            $.each(data, function (index, dvd) {
                var dvdId = dvd.dvdId;
                var title = dvd.title;
                var releaseYear = dvd.releaseYear;
                var director = dvd.director;
                var rating = dvd.rating;
                var note = dvd.note;
                
                var row = '<tr>';
                row += '<td><a onclick="showDetailForm(' + dvdId + ')">' + title + '</a></td>';
                row += '<td>' + releaseYear + '</td>';
                row += '<td>' + director.description + '</td>';
                row += '<td>' + rating.description + '</td>';
                row += '<td><a onclick="showEditForm(' + dvdId + ')">Edit</a></td>';
                row += '<td><a onclick="deleteDvd(' + dvdId + ')">Delete</a></td>';
                row += '</tr>';
                contentRows.append(row);
            })
        },
        error: function (xhr, textStatus, errorThrown) {
            showError("#divErrorE", xhr.responseText);
        }
    });
}

function clearContentRow() {
    $("#contentRows").empty();
}

$("#optCategory").change(function () {
    if ($("#optCategory").val() == "") {
        $("#txtSearch").attr("placeholder", "Search Term");
        return;
    } else {
        $("#txtSearch").attr("placeholder", "Search " + $("#optCategory").val());
    }
});

$("#btnSearch").click(function () {
    clearError("#divError");
    if ($("#optCategory").val() == "") {
        showError("#divError", "Please select search category.");
        return;
    }
    if ($("#txtSearch").val() == "") {
        showError("#divError", "Please input search text.");
        return;
    }
    loadData($("#optCategory").val(), $("#txtSearch").val());
});


$("#btnCreate").click(function () {
    showForm("#divAdd");
});

$("#btnSaveA").click(function () {
    var haveValidationErrors = checkAndDisplayValidationErrors($('#divAdd').find('input'), "#divErrorA");
    if (haveValidationErrors) {
        return false;
    }

    $.ajax({
        type: 'POST',
        url: 'http://localhost:54112/dvd',
        data: JSON.stringify({
            title: $('#txtTitleA').val(),
            releaseYear: $('#txtReleaseYearA').val(),
            directorId: $("#optDirA").val(),
            ratingId: $("#optRatingA").val(),
            note: $('#txtNoteA').val()
        }),
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        'dataType': 'json',
        success: function (data, status) {
            $('#divErrorA').empty();
            $('#txtTitleA').val('');
            $('#txtReleaseYearA').val('');
            //$('#txtDirectorA').val('');
            //$('#txtRatingA').val('');
            $('#txtNoteA').val('');
            showForm("#divList");
            loadData('', '');
        },
        error: function (xhr, textStatus, errorThrown) {
            showError("#divErrorE", xhr.responseText);         
        }
    });

});

function showError(location, message) {
    clearError(location);
    $(location + " p").empty().append(message).css({ "color": "red", "font-weight": "bold" });
    $(location).show();
}

function clearError(location) {
    $(location).hide();
}

function showEditForm(dvdId) {
    showForm("#divEdit");
    $.ajax({
        type: 'GET',
        url: 'http://localhost:54112/dvd/' + dvdId,
        success: function (dvd) {
            $("#txtIdE").val(dvd.dvdId);
            $("#txtTitleE").val(dvd.title);
            $("#txtReleaseYearE").val(dvd.releaseYear);
            //$("#txtDirectorE").val(dvd.director.directorId);
            //$("#txtRatingE").val(dvd.rating.ratingId);
            $('#optDirE').val(dvd.directorId).change();
            $('#optRatingE').val(dvd.ratingId).change();
            $("#txtNoteE").val(dvd.note);

        },
        error: function (xhr, textStatus, errorThrown) {
            showError("#divErrorE", xhr.responseText);
        }
    });
}


$("#btnSaveE").click(function () {
    var haveValidationErrors = checkAndDisplayValidationErrors($('#divEdit').find('input'), "#divErrorE");
    if (haveValidationErrors) {
        return false;
    }

    $.ajax({
        type: 'PUT',
        url: 'http://localhost:54112/dvd/' + $("#txtIdE").val(),
        data: 
            JSON.stringify({
                dvdId: $("#txtIdE").val(),
                Title: $('#txtTitleE').val(),
                releaseYear: $('#txtReleaseYearE').val(),
                directorId: $('#optDirE').val(),
                ratingId: $('#optRatingE').val(),
                note: $('#txtNoteE').val()
            })
        ,
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        'dataType': 'json',
        success: function (data, status) {
            $('#divErrorE').empty();
            $('#txtTitleA').val('');
            $('#txtReleaseYearE').val('');
            //$('#txtDirectorE').val('');
            //$('#txtRatingE').val('');
            $('#txtNoteE').val('');
            showForm("#divList");
            loadData('', '');
        },
        error: function (xhr, textStatus, errorThrown) {
            showError("#divErrorE", xhr.responseText);
        }
    });
});


function showDetailForm(dvdId) {
    showForm("#divDetail");
    $.ajax({
        type: 'GET',
        url: 'http://localhost:54112/dvd/' + dvdId,
        success: function (dvd) {
            $("#txtIdD").val(dvd.dvdId);
            $("#txtTitleD").val(dvd.title);
            $("#txtReleaseYearD").val(dvd.releaseYear);
            $("#txtDirectorD").val(dvd.director.description);
            $("#txtRatingD").val(dvd.rating.description);
            $("#txtNoteD").val(dvd.note);

        },
        error: function (xhr, textStatus, errorThrown) {
            showError("#divErrorE", xhr.responseText);
        }
    });
}

function deleteDvd(dvdId) {
    if (confirm("Are you sure you want to delete this DVD from your collection?") == true) {
        $.ajax({
            type: 'DELETE',
            url: "http://localhost:54112/dvd/" + dvdId,
            success: function (status) {
                loadData('', '');
            },
            error: function (xhr, textStatus, errorThrown) {
                showError("#divErrorE", xhr.responseText);
            }
        });


    }
}

$("#btnBackD, #btnCancelA, #btnCancelE").click(function () {
    showForm("#divList");
});

function showForm(formName) {
    $("#divList").hide();
    $("#divEdit").hide();
    $("#divDetail").hide();
    $("#divAdd").hide();

    $("#divErrorA").hide();
    $("#divErrorE").hide();
    $("#divError").hide();

    $(formName).show();
}

function checkAndDisplayValidationErrors(input, errorLocation) {
    $(errorLocation).empty();
    var errorMessages = [];
    
    input.each(function () {
        // Use the HTML5 validation API to find the validation errors
        if (!this.validity.valid) {
            var errorField = $('label[for=' + this.id + ']').text();
            errorMessages.push(errorField + ', ' + this.validationMessage.toString().toLowerCase());
        }
    });

    if (errorMessages.length > 0) {
        $.each(errorMessages, function (index, message) {
            $(errorLocation).show();
            $(errorLocation).append($('<li>').attr({ class: 'list-group-item list-group-item-danger' }).text(message));
        });
        return true;
    } else {
        return false;
    }
}


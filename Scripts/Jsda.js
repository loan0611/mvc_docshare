function check() {
    var x = $('#NhanDe').val();
    if (x == "") {
        alert('Hãy điền nhan đề vào');
        return false;
    }
    x = $('#SoTrang').val();
    if (x == "") {
        alert('Hãy điền số trang vào');
        return false;
    }
    x = $('#Phi').val();
    if (x == "") {
        alert('Hãy điền phí vào');
        return false;
    }
    x = $('#TuKhoa').val();
    if (x == "") {
        alert('Hãy điền từ khóa vào');
        return false;
    }
    x = $('#MaTacGia').val();
    if (x == "") {
        alert('Hãy điền tác giả vào');
        return false;
    }
    x = $('#MachuyenDe').val();
    if (x == "") {
        alert('Hãy điền chuyên đề vào');
        return false;
    }
    x = $('#MaNgonNgu').val();
    if (x == "") {
        alert('Hãy điền ngôn ngữ vào');
        return false;
    }
    var fup = document.getElementById('image');
    var imageName = fup.value;
    var ext = imageName.substring(imageName.lastIndexOf('.') + 1);
    if (ext != "gif" && ext != "GIF" && ext != "JPEG" && ext != "jpeg" && ext != "jpg" && ext != "JPG" && ext != "png") {
        alert("Upload images sai");
        return false;
    }
    //-------------------------
    var file = document.getElementById('file');
    var fileName = file.value;
    var exts = fileName.substring(fileName.lastIndexOf('.') + 1);
    if (exts != "doc" && exts != "docx" && exts != "pdf" && exts != "txt" && exts != ".rar" && exts != ".zip" && exts != "xlsx" && exts != "pptx") {
        alert("Upload file sai");
        return false;
    }
}
function checkInput() {
    var x = $('#seachtl').val();
    if (x == "") {
        alert('Hãy điền thông tin  vào');
        return false;
    }
}
function toggleLayer(whichLayer) {
    var elem, vis;
    if (document.getElementById) // this is the way the standards work
        elem = document.getElementById(whichLayer);
    else if (document.all) // this is the way old msie versions work
        elem = document.all[whichLayer];
    else if (document.layers) // this is the way nn4 works
        elem = document.layers[whichLayer];
    vis = elem.style;
    // if the style.display value is blank we try to figure it out here
    //if (vis.display == '' && elem.offsetWidth != undefined && elem.offsetHeight != undefined)
    //vis.display = (elem.offsetWidth != 0 && elem.offsetHeight != 0) ? 'none' : 'none';
    vis.display = (vis.display == '' || vis.display == 'block') ? 'none' : 'block';
}

//import js
document.write('<script src="/Areas/Content/Scripts/jquery.ui.widget.js"></script>');
document.write('<script src="/Areas/Content/Scripts/jquery.iframe-transport.js"></script>');
document.write('<script src="/Areas/Content/Scripts/jquery.fileupload.js"></script>');
//get param
var scripts = document.getElementsByTagName("script");
var currentScript = scripts[scripts.length - 1];
var scriptSrc = currentScript.src;

var fileUploadPath = scriptSrc.substr(scriptSrc.indexOf('=') + 1);

$(function () {
    $('.fileupload').fileupload({
        dataType: 'json',
        //add: function (e, data) {
        //    data.context = $('<p/>').text('Uploading...').appendTo(document.body);
        //    data.submit();
        //},
        done: function (e, data) {
            $.each(data.result.files, function (index, file) {
                $('<p/>').text(file.name).appendTo(document.body);
            });
            data.context.text('Upload finished.');
        },
        progressall: function (e, data) {
            var progress = parseInt(data.loaded / data.total * 100, 10);
            $('#progress .bar').css(
                'width',
                progress + '%'
            );
        }
    });
});

//progress
//<div id="progress">
//    <div class="bar" style="width: 0%;"></div>
//</div>
//.bar {
//    height: 18px;
//    background: green;
//}
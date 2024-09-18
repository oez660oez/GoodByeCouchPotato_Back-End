function previewImage(inputFile, Id) {
    if (inputFile.files && inputFile.files[0]) {
        var allowType = "image.*";
        if (inputFile.files[0].type.match(allowType)) {
            var reader = new FileReader();
            reader.onload = function (e) {
                // 設置預覽圖片的 src 和 title
                Id.attr("src", e.target.result);
                Id.attr("title", inputFile.files[0].name);
                $(".btn").prop("disabled", false);  // 啟用提交按鈕
            };
            reader.readAsDataURL(inputFile.files[0]);
        } else {
            alert("The file format is not supported.");
            $(".btn").prop("disabled", true);  // 禁用提交按鈕
        }
    }
}


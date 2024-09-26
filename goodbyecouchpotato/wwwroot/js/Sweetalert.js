function sweetalert(messagetype, successUrl) {
    if (messagetype) {
        Swal.fire({
            position: "center",
            icon: messagetype === 'success' ? "success" : "error",
            title: messagetype === 'success' ? "新增成功" : "新增失敗",
            showConfirmButton: true,
        //}).then((result) => {
        //    if (messagetype === 'success' && result.isConfirmed) {
        //        window.location.href = successUrl;  //點擊確定後指向新頁
        //    }
        });
    }
}


//因為商品在index做，不需要再做一次導向了
function sweetalertedit(messagetype) {
    if (messagetype) {
        Swal.fire({
            position: "center",
            icon: messagetype === 'success' ? "success" : "error",
            title: messagetype === 'success' ? "編輯成功" : "編輯失敗",
            showConfirmButton: true,
        });
    }
}
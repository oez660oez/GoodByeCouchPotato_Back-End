
//任務、商品和使用者新增用
function sweetalert(messagetype) {
    if (messagetype) {
        Swal.fire({
            position: "center",
            icon: messagetype === 'success' ? "success" : "error",
            title: messagetype === 'success' ? "新增成功" : "新增失敗",
            showConfirmButton: true,
        });
    }
}


//任務和商品修改用
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

//客服回覆用
function sweetalertopinion(messagetype) {
    if (messagetype) {
        Swal.fire({
            position: "center",
            icon: messagetype === 'success' ? "success" : "error",
            title: messagetype === 'success' ? "回覆成功" : "回覆失敗",
            showConfirmButton: true,
        });
    }
}

//覆核用
function sweetalertreview(messagetype) {
    if (messagetype) {
        Swal.fire({
            position: "center",
            icon: messagetype === '覆核成功' ? "success" : "error",
            title: messagetype === '覆核成功' ? "覆核成功" : "覆核失敗，查無該筆資料",
            showConfirmButton: true,
        }).then(function () { location.reload() });  //按下確認之後刷新
    }
}

//更改權限用
function sweetalertroles(messagetype) {
    if (messagetype) {
        Swal.fire({
            position: "center",
            icon: messagetype === 'success' ? "success" : "error",
            title: messagetype === 'success' ? "更改權限成功" : "更改權限失敗",
            showConfirmButton: true,
        });
    }
}
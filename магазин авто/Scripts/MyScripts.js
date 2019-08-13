function OnSuccess() {
    var bloc = document.getElementById('results');
    bloc.innerHTML = '';
    alert("Запрос был успешно выполнен. Получены следующие данные: \n" + data);
}
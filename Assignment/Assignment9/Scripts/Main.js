$(function () {
    $("#checkAll").click(function () {
        $("input[name='DepartmentsIdsToDelete']").attr("checked", this.checked);

        $("input[name='DepartmentsIdsToDelete']").click(function () {
            if ($("input[name='DepartmentsIdsToDelete']").length == $("input[name='DepartmentsIdsToDelete']:checked").length) {
                $("#checkAll").attr("checked", "checked");
            }
            else {
                $("#checkAll").removeAttr("checked");
            }
        });

    });
    $("#btnSubmit").click(function () {
        var count = $("input[name='DepartmentsIdsToDelete']:checked").length;
        if (count == 0) {
            alert("No rows selected to delete");
            return false;
        }
        else {
            return confirm(count + " row(s) will be deleted");
        }
    });
});
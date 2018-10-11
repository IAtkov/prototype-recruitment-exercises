(function () {
    var page = 2;
    var itemsPerPage = $('.load-more-btn').attr('data-itemsPerPage');
    var lastPage = 2;
    var loadedItemsCount = $('.load-more-btn').attr('data-loadedItems');
    if (parseInt(loadedItemsCount) < parseInt(itemsPerPage)) {
        $('.load-more-btn-wrapper').hide();
    }

    $('.change-type-of-job').on('click', function () {
        var typeOfJob = $(this).attr('data-typeOfJob');
        lastPage = $(this).attr('data-lastPage');

        page = 2;
        $('form[name="jobOpeningForm"] #typeOfJobSelected').val(typeOfJob);
        $('form[name="jobOpeningForm"').submit();
    });

    $('#loadMoreBtn').on('click', function () {
        var jobOpeningForm = $('form[name="jobOpeningForm"]');

        var model = {
            TypeOfJobSelected: jobOpeningForm.find('#typeOfJobSelected').val(),
            NationalityFilter: jobOpeningForm.find('#nationalityFilter').val(),
            GenderFilter: jobOpeningForm.find('#genderFilter').val(),
            DateFilter: jobOpeningForm.find('#dateFilter').val(),
            Page: page
        };

        $.ajax({
            type: 'GET',
            url: $('#loadMoreBtn').attr('data-url'),
            data: model,
            success: function (result) {
                if (result !== null) {
                    page++;
                    if (page > lastPage) {
                        $('.load-more-btn-wrapper').hide();
                    }

                    $(result).insertBefore('.load-more-btn-wrapper');
                }
            }
        });
    });

    $('#dateFilter').on('change', function () {
        $('form[name="jobOpeningForm"').submit();
    });

    $('#nationalityFilter').on('change', function () {
        $('form[name="jobOpeningForm"').submit();
    });

    $('#genderFilter').on('change', function () {
        $('form[name="jobOpeningForm"').submit();
    });

    $('#showHeaderMenuPopup').ready(function () {
        $("#showHeaderMenuPopup").hide();
        $("#menuicon").click(function () {
            $("#showHeaderMenuPopup").toggle();
        });
    });
})();
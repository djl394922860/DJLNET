'use strict';

jQuery(function ($) {

    // 设置全局 ajax ajaxError event handler
    $(document).ajaxError(function (event, jqxhr, settings, thrownError) {
        // request.responseText
        swal('请求错误!', "事件类型:"+ event.type +"状态码:" + jqxhr.status + ',请求路径:' + settings.url+"请求方式:"+ settings.type + ",错误内容如下:" + thrownError, 'error');
    });

    $('.easy-pie-chart.percentage').each(function () {
        var $box = $(this).closest('.infobox');
        var barColor = $(this).data('color') || (!$box.hasClass('infobox-dark') ? $box.css('color') : 'rgbas(255,255,255,0.95)');
        var trackColor = barColor == 'rgba(255,255,255,0.95)' ? 'rgba(255,255,255,0.25)' : '#E2E2E2';
        var size = parseInt($(this).data('size')) || 50;
        $(this).easyPieChart({
            barColor: barColor,
            trackColor: trackColor,
            scaleColor: false,
            lineCap: 'butt',
            lineWidth: parseInt(size / 10),
            animate: /msie\s*(8|7|6)/.test(navigator.userAgent.toLowerCase()) ? false : 1000,
            size: size
        });
    })

    $('.sparkline').each(function () {
        var $box = $(this).closest('.infobox');
        var barColor = !$box.hasClass('infobox-dark') ? $box.css('color') : '#FFF';
        $(this).sparkline('html', { tagValuesAttribute: 'data-values', type: 'bar', barColor: barColor, chartRangeMin: $(this).data('min') || 0 });
    });

    $('.dialogs,.comments').slimScroll({
        height: '300px'
    });

});
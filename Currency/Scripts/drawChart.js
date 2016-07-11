var uri = '/api/Currency/';

$(document).ready(function() {
    var today = new Date().toJSON().slice(0, 10);
    $('#rateDates').val(today);
    $.getJSON(uri + "date/" + $('#rateDates').val() + "/" + $('#daysBack').val())
        .done(function(data) {
            drawChart(prepareChartData(data));
        });
});

$('#rateDates').on('blur', function() {
    $.getJSON(uri + "date/" + this.value + "/" + $('#daysBack').val())
        .done(function(data) {
            drawChart(prepareChartData(data));
        });
});

$('#daysBack').on('blur', function() {
    $.getJSON(uri + "date/" + $('#rateDates').val() + "/" + this.value)
        .done(function(data) {
            drawChart(prepareChartData(data));
        });
});

$('#saveChart').submit(function(event) {
    var chartSrc = $('#chart_div img').prop('src');
    var savePath = "c:\\chart.png"
    event.preventDefault();
    $.ajax({
        type: "POST", 
        url: uri,
        data: {"": [chartSrc, savePath]},
        dataType: "json"
    });
});

function prepareChartData(data) {
    var chartData = [];
    $.each(data, function(i, value) {
        var date = value.date.replace(/-/g, ",");
        var temp = [];
        temp.push(new Date(date));
        $.each(value.rates, function(currency, rate) {
            temp.push(rate);
        });
        chartData.push(temp);
    });

    return chartData;
}

google.charts.load('current', {
    'packages': ['corechart']
});



function drawChart(chartData) {

    var data = new google.visualization.DataTable();
    data.addColumn('date', 'X');
    data.addColumn('number', 'CHF');
    data.addColumn('number', 'EUR');
    data.addColumn('number', 'GBP');
    data.addColumn('number', 'USD');

    data.addRows(chartData);

    var options = {
        title: 'Currency rates',
        width: 900,
        height: 500,
        hAxis: {
            format: 'M/d/yy',
            title: 'Date'
        },
        vAxis: {
            title: 'Price',
            viewWindowMode: 'pretty'
        },
    };


    var chart = new google.visualization.LineChart(document.getElementById('chart_div'));
    // Wait for the chart to finish drawing before calling the getImageURI() method.
    google.visualization.events.addListener(chart, 'ready', function() {
        chart_div.innerHTML = '<img src="' + chart.getImageURI() + '">';
    });
    chart.draw(data, options);
}

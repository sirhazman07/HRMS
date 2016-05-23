﻿function createChart() {
    $("#doughnutChart").kendoChart({
        title: {
            text: "What are Enhancement Request's based on?"
        },
        legend: {
            position: "top"
        },
        seriesDefaults: {
            labels: {
                template: "#= category # - #= kendo.format('{0:P}', percentage)#",
                position: "outsideEnd",
                visible: true,
                background: "transparent"
            }
        },
        series: [{
            type: "donut",
            data: [{
                category: "Point of Sales System",
                value: 35
            }, {
                category: "PayRoll Systems",
                value: 25
            }, {
                category: "Rostering Systems",
                value: 20
            }, {
                category: "Support Systems",
                value: 10
            }, {
                category: "Other",
                value: 10
            }]
        }],
        tooltip: {
            visible: true,
            template: "#= category # - #= kendo.format('{0:P}', percentage) #"
        }
    });
}

$(document).ready(function () {
    createChart();
    $(document).bind("kendo:skinChange", createChart);
    $(".box").bind("change", refresh);
});

function refresh() {
    var chart = $("#chart").data("kendoChart"),
        pieSeries = chart.options.series[0],
        labels = $("#labels").prop("checked"),
        alignInputs = $("input[name='alignType']"),
        alignLabels = alignInputs.filter(":checked").val();

    chart.options.transitions = false;
    pieSeries.labels.visible = labels;
    pieSeries.labels.align = alignLabels;

    alignInputs.attr("disabled", !labels);

    chart.refresh();
}
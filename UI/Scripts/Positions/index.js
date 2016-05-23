﻿$(function () {

    //========== editor table Employee Datasource popup dropdown list ===================
    var employeesDS = new kendo.data.DataSource({
        transport: {
            read: {
                url: "/api/Employees",
                type: "GET",
                dataType: "json",                
            },
            parameterMap: function (data, type) {
                return kendo.stringify(data); 
            }
        }

    });
    
    //employeesDS.fetch();

    //===============  Editor table Postion datasource popup dropdown list  =======================
    var positionDS = new kendo.data.DataSource({
        transport: {
            read: {
                url: "/api/Positions/GetPositions",
                type: "GET",
                datatype: "json",
            },
            parametermap: function (data, type) {
                return kendo.stringify(data);
            }
        }
    });

    //positionDS.fetch();

    //====================  Editor edit table active  =========================
    var data = kendo.Observable({
        Active: true
    });

   //=================  EmployeeInPosition Data Source  ======================
    var employeeInPositionDS = new kendo.data.DataSource({

        transport: {
            read: {
                url: "/api/Positions/Read",
                type: "GET",
                dataType: "json",                
            },
            create: {
                url: "/api/Positions/RegisterEmployeeInPosition",
                type: "POST",
                dataType: "json",
                contentType: "application/json"
            },
            update: {
                url: "/api/Positions/Update",
                type: "PUT",
                dataType: "json",               
                contentType: "application/json"
            },
            destroy: {
                url: "/api/Positions/Delete",
                type: "DELETE",
                contentType: "application/json"
            },
            parameterMap: function (data, type) {
                return kendo.stringify(data);
            }
        },
        batch: false,
        pageSize: 10,
        schema: {
            model: {
                id: "Id",
                fields: {
                    Id: {type: "number", editable: false},
                    EmployeeId: { type: "number", validation: { required: true, min: 1 }, from: "EmployeeId" },
                    Employee: {defaultValue:{FirstName:"",LastName:""}},
                    PositionId: { type: "number", validation: { required: true, min: 1, max: 4 }, from: "PositionId" },
                    Position:{defaultValue: {Name:""}},
                    Active: { type: "boolean", from: "Active" },
                }
            }
        }
    });


 //========================  EmployeeInPosition grid  =====================
    $("#grid").kendoGrid({
        dataSource: employeeInPositionDS,
        sortable: true,
        pageable: true,
        toolbar: ["create"],
        editable: {
            mode: "popup",
            template: kendo.template($("#popup-editor").html())    
        },

        edit: function (e) {

            var employeeElement = e.container.find("input[name=\"EmployeeId\"]");

            employeeElement.kendoDropDownList({
                dataSource: employeesDS,
                optionLabel: " "
        //            change: function(e) {
        //            debugger;
        //}
        });

            var positionElement = e.container.find("#PositionId");

            positionElement.kendoDropDownList({
            dataSource: positionDS,
            optionLabel: " "
        });

            //e.container.find("input[name=\"EmployeeId\"]").data("kendoDropDownList").setDataSource(employeesDS);
            //e.container.find("#PositionId").data("kendoDropDownList").setDataSource(positionDS);
        },

        columns: [
        { field: "Id"},
        { field: "EmployeeId", title: "Employee" },        
        { field: "Employee.FirstName", title: "First Name" },
        { field: "Employee.LastName", title: "Last Name" },
        { field: "PositionId", title: "Position" },
        { field: "Position.Name", title: "Position"},
        { field: "Active", title: "Active" },
        { command: ["edit", "destroy"], title: "&nbsp;" },               
        ],
    });
});
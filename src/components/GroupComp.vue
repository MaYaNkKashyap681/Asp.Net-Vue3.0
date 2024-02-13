<!--<template>
    <div id="app-container">
        <DxDataGrid id="dataGrid"
                    :data-source="employees"
                    key-expr="EmployeeID"
                    :allow-column-resizing="true"
                    :column-auto-width="true"
                    :allow-column-reordering="true"
                    @selection-changed="selectEmployee"
                    @exporting="exportGrid">
            <DxColumn data-field="FullName" :fixed="true">
                <DxRequiredRule />
            </DxColumn>
            <DxColumn data-field="Position">
                <DxRequiredRule />
            </DxColumn>
            <DxColumn data-field="BirthDate"
                      data-type="date"
                      :width="100">
                <DxRequiredRule />
            </DxColumn>
            <DxColumn data-field="HireDate"
                      data-type="date"
                      :width="100">
                <DxRequiredRule />
            </DxColumn>
            <DxColumn data-field="City" />
            <DxColumn data-field="Country"
                      :group-index="0"
                      sort-order="asc">
                <DxRequiredRule />
            </DxColumn>
            <DxColumn data-field="Address" />
            <DxColumn data-field="HomePhone" />
            <DxColumn data-field="PostalCode" :visible="false" />
            <DxColumnChooser :enabled="true" />
            <DxColumnFixing :enabled="true" />
            <DxFilterRow :visible="true" />
            <DxSearchPanel :visible="true" />
            <DxGroupPanel :visible="true" />
            <DxSelection mode="single" />
            <DxSummary>
                <DxGroupItem summary-type="count" />
            </DxSummary>
            <DxEditing mode="popup"
                       :allow-updating="true"
                       :allow-adding="true"
                       :allow-deleting="true" />
            <DxGrouping :auto-expand-all="expanded" />
            <DxToolbar>
                <DxItem name="groupPanel" />
                <DxItem location="after" template="button-template" />
                <DxItem name="addRowButton" show-text="always" />
                <DxItem name="exportButton" />
                <DxItem name="columnChooserButton" />
                <DxItem name="searchPanel" />
            </DxToolbar>
            <template #button-template>
                <DxButton :text="expanded ? 'Collapse All' : 'Expand All'"
                          :width="136"
                          @click="expanded = !expanded" />
            </template>
            <DxMasterDetail :enabled="true"
                            template="employee-info" />
            <template #employee-info="{ data: employee }">
                <div>
                    <img class="employee-photo" :src="employee.data.Photo">
                    <p class="employee-notes">{{ employee.data.Notes }}</p>
                </div>
            </template>
            <DxExport :enabled="true"
                      :formats="['xlsx', 'pdf']" />
        </DxDataGrid>
        <p id="selected-employee" v-if="selectedEmployee">
            Selected employee: {{ selectedEmployee.FullName }}
        </p>
    </div>
</template>

<script>
    import {
        DxDataGrid,
        DxColumn,
        DxRequiredRule,
        DxColumnChooser,
        DxColumnFixing,
        DxFilterRow,
        DxSearchPanel,
        DxGroupPanel,
        DxSelection,
        DxSummary,
        DxGroupItem,
        DxEditing,
        DxGrouping,
        DxToolbar,
        DxItem,
        DxMasterDetail,
        DxExport
    } from 'devextreme-vue/data-grid';
    import { DxButton } from 'devextreme-vue/button';

    const employees = [{
        "EmployeeID": 1,
        "FullName": "Nancy Davolio",
        "Position": "Sales Representative",
        "TitleOfCourtesy": "Ms.",
        "BirthDate": "1968-12-08T00:00:00.000Z",
        "HireDate": "2011-05-01T00:00:00.000Z",
        "Address": "507 - 20th Ave. E.\r\nApt. 2A",
        "City": "Seattle",
        "Region": "WA",
        "PostalCode": "98122",
        "Country": "USA",
        "HomePhone": "(206) 555-9857",
        "Extension": "5467",
        "Photo": "https://js.devexpress.com/Demos/WidgetsGallery/JSDemos/images/employees/06.png",
        "Notes": "Education includes a BA in psychology from Colorado State University in 1990.  She also completed \"The Art of the Cold Call.\"  Nancy is a member of Toastmasters International.",
        "ReportsTo": 2
    }, {
        "EmployeeID": 2,
        "FullName": "Andrew Fuller",
        "Position": "Vice President, Sales",
        "TitleOfCourtesy": "Dr.",
        "BirthDate": "1972-02-19T00:00:00.000Z",
        "HireDate": "2011-08-14T00:00:00.000Z",
        "Address": "908 W. Capital Way",
        "City": "Tacoma",
        "Region": "WA",
        "PostalCode": "98401",
        "Country": "USA",
        "HomePhone": "(206) 555-9482",
        "Extension": "3457",
        "Photo": "https://js.devexpress.com/Demos/WidgetsGallery/JSDemos/images/employees/02.png",
        "Notes": "Andrew received his BTS commercial in 1994 and a Ph.D. in international marketing from the University of Dallas in 2001.  He is fluent in French and Italian and reads German.  He joined the company as a sales representative, was promoted to sales manager in January 2012 and to vice president of sales in March 2013.  Andrew is a member of the Sales Management Roundtable, the Seattle Chamber of Commerce, and the Pacific Rim Importers Association.",
        "ReportsTo": null
    }, {
        "EmployeeID": 3,
        "FullName": "Janet Leverling",
        "Position": "Sales Representative",
        "TitleOfCourtesy": "Ms.",
        "BirthDate": "1983-08-30T00:00:00.000Z",
        "HireDate": "2011-04-01T00:00:00.000Z",
        "Address": "722 Moss Bay Blvd.",
        "City": "Kirkland",
        "Region": "WA",
        "PostalCode": "98033",
        "Country": "USA",
        "HomePhone": "(206) 555-3412",
        "Extension": "3355",
        "Photo": "https://js.devexpress.com/Demos/WidgetsGallery/JSDemos/images/employees/09.png",
        "Notes": "Janet has a BS degree in chemistry from Boston College (2004).  She has also completed a certificate program in food retailing management.  Janet was hired as a sales associate in 2011 and promoted to sales representative in February 2012.",
        "ReportsTo": 2
    }, {
        "EmployeeID": 4,
        "FullName": "Margaret Peacock",
        "Position": "Sales Representative",
        "TitleOfCourtesy": "Mrs.",
        "BirthDate": "1957-09-19T00:00:00.000Z",
        "HireDate": "2012-05-03T00:00:00.000Z",
        "Address": "4110 Old Redmond Rd.",
        "City": "Redmond",
        "Region": "WA",
        "PostalCode": "98052",
        "Country": "USA",
        "HomePhone": "(206) 555-8122",
        "Extension": "5176",
        "Photo": "https://js.devexpress.com/Demos/WidgetsGallery/JSDemos/images/employees/04.png",
        "Notes": "Margaret holds a BA in English literature from Concordia College (1978) and an MA from the American Institute of Culinary Arts (1986).  She was assigned to the London office temporarily from July through November 2012.",
        "ReportsTo": 2
    }, {
        "EmployeeID": 5,
        "FullName": "Steven Buchanan",
        "Position": "Sales Manager",
        "TitleOfCourtesy": "Mr.",
        "BirthDate": "1975-03-04T00:00:00.000Z",
        "HireDate": "2012-10-17T00:00:00.000Z",
        "Address": "14 Garrett Hill",
        "City": "London",
        "Region": "UK",
        "PostalCode": "SW1 8JR",
        "Country": "UK",
        "HomePhone": "(71) 555-4848",
        "Extension": "3453",
        "Photo": "https://js.devexpress.com/Demos/WidgetsGallery/JSDemos/images/employees/05.png",
        "Notes": "Steven Buchanan graduated from St. Andrews University, Scotland, with a BSC degree in 1996.  Upon joining the company as a sales representative in 2012, he spent 6 months in an orientation program at the Seattle office and then returned to his permanent post in London.  He was promoted to sales manager in March 2013.  Mr. Buchanan has completed the courses \"Successful Telemarketing\" and \"International Sales Management.\"  He is fluent in French.",
        "ReportsTo": 2
    }, {
        "EmployeeID": 6,
        "FullName": "Michael Suyama",
        "Position": "Sales Representative",
        "TitleOfCourtesy": "Mr.",
        "BirthDate": "1983-07-02T00:00:00.000Z",
        "HireDate": "2012-10-17T00:00:00.000Z",
        "Address": "Coventry House\r\nMiner Rd.",
        "City": "London",
        "Region": "UK",
        "PostalCode": "EC2 7JR",
        "Country": "UK",
        "HomePhone": "(71) 555-7773",
        "Extension": "428",
        "Photo": "https://js.devexpress.com/Demos/WidgetsGallery/JSDemos/images/employees/01.png",
        "Notes": "Michael is a graduate of Sussex University (MA, economics, 2003) and the University of California at Los Angeles (MBA, marketing, 2006). He has also taken the courses \"Multi-Cultural Selling\" and \"Time Management for the Sales Professional.\"  He is fluent in Japanese and can read and write French, Portuguese, and Spanish.",
        "ReportsTo": 5
    }, {
        "EmployeeID": 7,
        "FullName": "Robert King",
        "Position": "Sales Representative",
        "TitleOfCourtesy": "Mr.",
        "BirthDate": "1980-05-29T00:00:00.000Z",
        "HireDate": "2012-01-02T00:00:00.000Z",
        "Address": "Edgeham Hollow\r\nWinchester Way",
        "City": "London",
        "Region": "UK",
        "PostalCode": "RG1 9SP",
        "Country": "UK",
        "HomePhone": "(71) 555-5598",
        "Extension": "465",
        "Photo": "https://js.devexpress.com/Demos/WidgetsGallery/JSDemos/images/employees/07.png",
        "Notes": "Robert King served in the Peace Corps and traveled extensively before completing his degree in English at the University of Michigan in 2002, the year he joined the company.  After completing a course entitled \"Selling in Europe,\" he was transferred to the London office in March 2013.",
        "ReportsTo": 5
    }, {
        "EmployeeID": 8,
        "FullName": "Laura Callahan",
        "Position": "Inside Sales Coordinator",
        "TitleOfCourtesy": "Ms.",
        "BirthDate": "1978-01-09T00:00:00.000Z",
        "HireDate": "2012-03-05T00:00:00.000Z",
        "Address": "4726 - 11th Ave. N.E.",
        "City": "Seattle",
        "Region": "WA",
        "PostalCode": "98105",
        "Country": "USA",
        "HomePhone": "(206) 555-1189",
        "Extension": "2344",
        "Photo": "https://js.devexpress.com/Demos/WidgetsGallery/JSDemos/images/employees/08.png",
        "Notes": "Laura received a BA in psychology from the University of Washington.  She has also completed a course in business French.  She reads and writes French.",
        "ReportsTo": 2
    }, {
        "EmployeeID": 9,
        "FullName": "Brett Wade",
        "Position": "Sales Representative",
        "TitleOfCourtesy": "Mr.",
        "BirthDate": "1986-01-27T00:00:00.000Z",
        "HireDate": "2012-11-15T00:00:00.000Z",
        "Address": "7 Houndstooth Rd.",
        "City": "London",
        "Region": "UK",
        "PostalCode": "WG2 7LT",
        "Country": "UK",
        "HomePhone": "(71) 555-4444",
        "Extension": "452",
        "Photo": "https://js.devexpress.com/Demos/WidgetsGallery/JSDemos/images/employees/03.png",
        "Notes": "Brett has a BA degree in English from St. Lawrence College.  He is fluent in French and German.",
        "ReportsTo": 5
    }];

    export default {
        name: 'App',
        components: {
            DxDataGrid,
            DxColumn,
            DxRequiredRule,
            DxColumnChooser,
            DxColumnFixing,
            DxFilterRow,
            DxSearchPanel,
            DxGroupPanel,
            DxSelection,
            DxSummary,
            DxGroupItem,
            DxEditing,
            DxGrouping,
            DxToolbar,
            DxItem,
            DxMasterDetail,
            DxExport,
            DxButton
        },
        data() {
            return {
                employees: employees,
                selectedEmployee: undefined,
                expanded: true
            }
        },
    }
</script>

<style>
    .employee-photo {
        height: 140px;
        float: left;
        padding: 0 20px 20px 0;
    }

    .employee-notes {
        text-align: justify;
        white-space: normal;
    }

    #dataGrid {
        height: 500px;
    }

    #app-container {
        width: 900px;
        position: relative;
    }

    #selected-employee {
        position: absolute;
        left: 50%;
        transform: translate(-50%, 0);
    }
</style>-->

<template>
    <!-- <div>
         <h1>Employee Photos</h1>
         <div v-if="employeesData.length === 0">No employee data available</div>
         <div v-else>
             <div v-for="(employee, index) in employeesData" :key="index">
                 <img :src="employee.photo" :alt="`Photo of ${employee.fullName}`" style="width: 100px; height: 100px;">
                 <p>{{ employee.fullName }}</p>
             </div>
         </div>
     </div>-->

    <div id="app-container">
        <DxDataGrid id="dataGrid"
                    :data-source="employeesData"
                    key-expr="employeeID"
                    :allow-column-resizing="true"
                    :column-auto-width="true"
                    :allow-column-reordering="true"
                    @selection-changed="selectEmployee"
                    @exporting="exportGrid">
            <DxColumn data-field="fullName" :fixed="true">
                <DxRequiredRule />
            </DxColumn>
            <DxColumn data-field="position">
                <DxRequiredRule />
            </DxColumn>
            <DxColumn data-field="birthDate"
                      data-type="date"
                      :width="100">
                <DxRequiredRule />
            </DxColumn>
            <DxColumn data-field="hireDate"
                      data-type="date"
                      :width="100">
                <DxRequiredRule />
            </DxColumn>
            <DxColumn data-field="city" />
            <DxColumn data-field="country"
                      :group-index="0"
                      sort-order="asc">
                <DxRequiredRule />
            </DxColumn>
            <DxColumn data-field="address" />
            <DxColumn data-field="homePhone" />
            <DxColumn data-field="postalCode" :visible="false" />
            <DxColumnChooser :enabled="true" />
            <DxColumnFixing :enabled="true" />
            <DxFilterRow :visible="true" />
            <DxSearchPanel :visible="true" />
            <DxGroupPanel :visible="true" />
            <DxSelection mode="single" />
            <DxSummary>
                <DxGroupItem summary-type="count" />
            </DxSummary>
            <DxEditing mode="popup"
                       :allow-updating="true"
                       :allow-adding="true"
                       :allow-deleting="true" />
            <DxGrouping :auto-expand-all="expanded" />
            <DxToolbar>
                <DxItem name="groupPanel" />
                <DxItem location="after" template="button-template" />
                <DxItem name="addRowButton" show-text="always" />
                <DxItem name="exportButton" />
                <DxItem name="columnChooserButton" />
                <DxItem name="searchPanel" />
            </DxToolbar>
            <template #button-template>
                <DxButton :text="expanded ? 'Collapse All' : 'Expand All'"
                          :width="136"
                          @click="expanded = !expanded" />
            </template>
            <DxMasterDetail :enabled="true"
                            template="employee-info" />
            <template #employee-info="{ data: employee }">
                <div>
                    <img class="employee-photo" :src="employee.data.Photo">
                    <p class="employee-notes">{{ employee.data.notes }}</p>
                </div>
            </template>
            <DxExport :enabled="true"
                      :formats="['xlsx', 'pdf']" />
        </DxDataGrid>
        <p id="selected-employee" v-if="selectedEmployee">
            Selected employee: {{ selectedEmployee.fullName }}
        </p>
    </div>
</template>

<script setup>
    import {
        DxDataGrid,
        DxColumn,
        DxRequiredRule,
        DxColumnChooser,
        DxColumnFixing,
        DxFilterRow,
        DxSearchPanel,
        DxGroupPanel,
        DxSelection,
        DxSummary,
        DxGroupItem,
        DxEditing,
        DxGrouping,
        DxToolbar,
        DxItem,
        DxMasterDetail,
        DxExport
    } from 'devextreme-vue/data-grid';
    import { DxButton } from 'devextreme-vue/button';
    import { defineProps } from 'vue';

    const props = defineProps({
        employeesData: {
            type: Array,
            required: true
        }
    });

    console.log("Coming from the Main component", props.employeesData);
    console.log(props);
</script>



<style scoped>
</style>


<!--<template>
       <h1> This is MyText: {{ myText }}</h1>
</template>

<script setup>

    import { defineProps } from 'vue'

    const props = defineProps({
        myText: {
            type: String,
            required: true
        }
    })

    console.log(props);
</script>-->

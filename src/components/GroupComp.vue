
<template>
     <div>
         <h1>Employee Photos</h1>
         <div v-if="employeesData.length === 0">No employee data available</div>
         <div v-else>
             <div v-for="(employee, index) in employeesData" :key="index">
                 <img :src="employee.photo" :alt="`Photo of ${employee.fullName}`" style="width: 100px; height: 100px;">
                 <p>{{ employee.fullName }}</p>
             </div>
         </div>
     </div>

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

    <h1>Submitting From</h1>
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
  /*  import { defineProps } from 'vue';*/

    const employeesData = [
        {
            EmployeeID: 5,
            FullName: "John Doe",
            Position: "Manager",
            TitleOfCourtesy: "Mr.",
        /*    BirthDate: new DateTime(1980, 5, 10),
            HireDate: new DateTime(2005, 9, 15),*/
            Address: "123 Main St.",
            City: "Anytown",
            Region: "Region",
            PostalCode: "12345",
            Country: "USA",
            HomePhone :"(123) 456-7890",
            Extension: "100",
            Photo: "https://images.unsplash.com/photo-1706391740145-19c93b1cda9a?w=600&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHw0M3x8fGVufDB8fHx8fA%3D%3D",
            Notes: "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
            ReportsTo: null
        },
        {
            EmployeeID: 5,
            FullName: "John Doe",
            Position: "Manager",
            TitleOfCourtesy: "Mr.",
         /*   BirthDate: new DateTime(1980, 5, 10),
            HireDate: new DateTime(2005, 9, 15),*/
            Address: "123 Main St.",
            City: "Anytown",
            Region: "Region",
            PostalCode: "12345",
            Country: "USA",
            HomePhone: "(123) 456-7890",
            Extension: "100",
            Photo: "https://images.unsplash.com/photo-1706391740145-19c93b1cda9a?w=600&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHw0M3x8fGVufDB8fHx8fA%3D%3D",
            Notes: "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
            ReportsTo: null
        },
    ]
   /* const props = defineProps({
        employeesData: {
            type: Array,
            required: true
        }
    });

    console.log("Coming from the Main component", props.employeesData);
    console.log(props);*/
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
</script>
-->



<!--<template>
    <div>
        <h1>Post Data Form</h1>
        <form @submit.prevent="handleSubmit">
            <div>
                <label for="name">Name:</label>
                <input type="text" id="name" v-model="formData.name">
            </div>
            <div>
                <label for="age">Age:</label>
                <input type="number" id="age" v-model="formData.age">
            </div>
            <button type="submit">Submit</button>
        </form>
    </div>
</template>

<script setup>
    import { ref } from 'vue';

    const formData = ref({
        name: '',
        age: null
    });

    const handleSubmit = () => {
        fetch('http://localhost:5047/group/SubmitData2', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(formData.value)
        })
            .then(response => {
                if (response.ok) {
                    alert('Data posted successfully');
                    window.location.href = "http://localhost:5047/"
                    formData.value = { name: '', age: null };
                } else {
                    console.error('Failed to post data');
                }
            })
            .catch(error => {
                console.error('Error posting data:', error);
            });
    };
</script>
-->

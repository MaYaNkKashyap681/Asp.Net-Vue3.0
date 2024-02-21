<template>
    <div>
        <h1 v-for="elem of fetchedData" :key="elem.id">
            {{ elem.name }}
        </h1>
    </div>
</template>

<script setup>
import { watchEffect, ref } from 'vue';

const fetchedData = ref([]);

watchEffect(async () => {
    try {
        const url = 'http://localhost:5047/panel/details';
        const response = await fetch(url);
        if (!response.ok) {
            throw new Error('Failed to fetch data');
        }
        const jsonData = await response.json();
        fetchedData.value = jsonData;
    } catch (error) {
        console.error('Error fetching data:', error);
    }
});
</script>

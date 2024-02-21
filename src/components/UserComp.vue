<!--<template>
    <h1>Hello Mayank Vue 3 Hello Hello dbsbosbfcb</h1>
    <a href="/group/index">Press Me To Take to Group</a>
</template>

-->

<template>
    <div class="maindiv">

        <div class="side-panel">
            <ul class="flex flex-col">
                <li class="panel-item" @click="handleClick(1)">Panel1</li>
                <li class="panel-item" @click="handleClick(2)">Panel2</li>
                <li class="panel-item" @click="handleClick(3)">Panel3</li>
            </ul>
        </div>

        <div :class="{ 'main-panel-expanded': visibleTabLevel1 === 1, 'main-panel-collapsed': visibleTabLevel1 !== 1 }">
            <ul v-if="visibleTabLevel1 === 1">
                <li @click="handleClickSubTab(1)" class="sub-panel-item">Sub Panel1</li>
                <li @click="handleClickSubTab(2)" class="sub-panel-item">Sub Panel2</li>
                <li class="sub-panel-item">Sub Panel3</li>
                <li class="sub-panel-item">Sub Panel4</li>
                <li class="sub-panel-item">Sub Panel5</li>
            </ul>
        </div>

        <div class="sub-panel" v-if="visibleTabLevel1 === 2">
            <ul>
                <li class="sub-panel-item">Sub Panel1</li>
                <li class="sub-panel-item">Sub Panel2</li>
            </ul>
        </div>

        <div class="sub-panel" v-if="visibleTabLevel1 === 3">
            <ul>
                <li class="sub-panel-item">Sub Panel1</li>
                <li class="sub-panel-item">Sub Panel2</li>
                <li class="sub-panel-item">Sub Panel3</li>
            </ul>
        </div>

        <div class="sub-sub-panel" v-if="visibleSubTabLevel2 === 1">
            <ul>
                <li class="sub-sub-panel-item">Sub Sub Panel11</li>
                <li class="sub-sub-panel-item">Sub Sub Panel12</li>
            </ul>
        </div>

        <div class="sub-sub-panel" v-if="visibleSubTabLevel2 === 2">
            <ul>
                <li class="sub-sub-panel-item">Sub Sub Panel21</li>
                <li class="sub-sub-panel-item">Sub Sub Panel22</li>
            </ul>
        </div>

    </div>
</template>

<script setup>
    import { ref } from 'vue';

    const visibleTabLevel1 = ref(0);
    const visibleSubTabLevel2 = ref(0);

    const handleClick = (visibleTab) => {
        visibleTabLevel1.value = visibleTab;
    }

    const handleClickSubTab = (visbleSubTab) => {
        visibleSubTabLevel2.value = visbleSubTab;
    }
</script>

<style>

    .maindiv {
        height: 100vh;
        display: flex;
    }
    /* Plain CSS */
    .side-panel {
        width: 200px;
        height: 100%;
        border-right-width: 4px;
    }

    .panel-item {
        padding: 1rem;
        display: flex;
        align-items: center;
        justify-content: center;
        cursor: pointer;
        background-color: #4299e1;
        transition: background-color 300ms ease-out;
    }

        .panel-item:hover {
            background-color: rgba(66, 153, 225, 0.4);
        }

    .main-panel-expanded {
        width: 300px;
        border-right-width: 4px;
        transition: width 300ms ease-out;
    }

    .main-panel-collapsed {
        width: 0;
        overflow: hidden;
        border-right-width: 0;
        transition: width 300ms ease-out;
    }

    .sub-panel {
        width: 300px;
        height: 100%;
        border-right-width: 4px;
        transition: width 300ms ease-out;
    }

        .sub-panel ul {
            padding: 0;
        }

    .sub-panel-item {
        padding: 1rem;
        display: flex;
        align-items: center;
        justify-content: center;
        cursor: pointer;
        transition: background-color 300ms ease-out;
    }

        .sub-panel-item:hover {
            background-color: rgba(107, 114, 128, 0.4);
        }

    .sub-sub-panel {
        width: 300px;
        height: 100%;
        border-right-width: 4px;
        transition: width 300ms ease-out;
    }

    .sub-sub-panel-item {
        padding: 1rem;
        display: flex;
        align-items: center;
        justify-content: center;
        cursor: pointer;
        transition: background-color 300ms ease-out;
    }

        .sub-sub-panel-item:hover {
            background-color: rgba(79, 70, 229, 0.4);
        }

    /* End of Plain CSS */
</style>

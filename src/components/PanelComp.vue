<template>
    <div class="h-screen flex overflow-x-scroll">
        <div class="w-[200px] h-full transition-all duration-200 border-r-[4px] relative" ref="parentDiv">

            <div v-if="isMinimized" @click="handleResetScreenClick()" class="w-full h-full bg-blue-200 flex items-center justify-center cursor-pointer hover:bg-opacity-40">
                <h2 class="rotate-[-90deg] whitespace-nowrap font-bold text-2xl">Panel 1</h2>
            </div>
            <div v-if="isMinimized === false">
                <div class="bg-white  h-8">
                    <div class="ml-auto flex gap-8">
                        <p class="cursor-pointer" @click="handleMinimizeScreenClick()">M</p>
                        <p class="cursor-pointer" @click="handleResetScreenClick()">R</p>
                        <p class="cursor-pointer" @click="handleFullScreenClick()">F</p>
                        <p class="cursor-pointer" @click="handleHalfScreenClick()">H</p>
                    </div>
                </div>
                <div class="absolute w-[4px] h-full bg-transparent-300 right-[-4px] cursor-e-resize hover:bg-blue-200"
                     ref="resizer"></div>
                <ul class="flex flex-col">
                    <li class="p-4 flex items-center justify-center bg-blue-400 cursor-pointer hover:bg-opacity-40"
                        @click="handleClick(1)">Panel1</li>
                    <li class="p-4 flex items-center justify-center bg-pink-400 cursor-pointer hover:bg-opacity-40"
                        @click="handleClick(2)">Panel2</li>
                    <li class="p-4 flex items-center justify-center bg-yellow-400 cursor-pointer hover:bg-opacity-40"
                        @click="handleClick(3)">Panel3</li>
                </ul>
            </div>
        </div>

        <div :class="visibleTabLevel1 === 1 ? 'w-[300px] border-r-[4px]' : 'w-[0px]'"
             class="h-full  transition-all duration-300 ease-out">
            <div v-if="visibleTabLevel1 === 1">
                <PanelItem />
            </div>
            <!--<ul v-if="visibleTabLevel1 === 1">
                <li @click="handleClickSubTab(1)"
                    class="p-4 flex items-center justify-center bg-blue-700 cursor-pointer hover:bg-opacity-40">Sub Panel1</li>
                <li @click="handleClickSubTab(2)"
                    class="p-4 flex items-center justify-center bg-pink-700 cursor-pointer hover:bg-opacity-40">Sub Panel2</li>
                <li class="p-4 flex items-center justify-center bg-yellow-700 cursor-pointer hover:bg-opacity-40">Sub Panel3</li>
                <li class="p-4 flex items-center justify-center bg-green-700 cursor-pointer hover:bg-opacity-40">Sub Panel4</li>
                <li class="p-4 flex items-center justify-center bg-violet-700 cursor-pointer hover:bg-opacity-40">Sub Panel5</li>
            </ul>-->
        </div>
        <div class="w-[300px] h-full border-r-[4px]" v-if="visibleTabLevel1 === 2">
            <ul>
                <li class="p-4 flex items-center justify-center bg-blue-700 cursor-pointer hover:bg-opacity-40">Sub Panel1</li>
                <li class="p-4 flex items-center justify-center bg-pink-700 cursor-pointer hover:bg-opacity-40">Sub Panel2</li>
            </ul>
        </div>
        <div class="w-[300px] h-full border-r-[4px]" v-if="visibleTabLevel1 === 3">
            <ul>
                <li class="p-4 flex items-center justify-center bg-purple-700 cursor-pointer hover:bg-opacity-40">Sub Panel1</li>
                <li class="p-4 flex items-center justify-center bg-zinc-700 cursor-pointer hover:bg-opacity-40">Sub Panel2</li>
                <li class="p-4 flex items-center justify-center bg-yellow-700 cursor-pointer hover:bg-opacity-40">Sub Panel3</li>
            </ul>
        </div>


        <div class="w-[300px] h-full border-r-[4px]" v-if="visibleSubTabLevel2 === 1">
            <ul>
                <li class="p-4 flex items-center justify-center bg-blue-700 cursor-pointer hover:bg-opacity-40">
                    Sub Sub Panel11
                </li>
                <li class="p-4 flex items-center justify-center bg-pink-700 cursor-pointer hover:bg-opacity-40">
                    Sub Sub Panel12
                </li>
            </ul>
        </div>
        <div class="w-[300px] h-full border-r-[4px]" v-if="visibleSubTabLevel2 === 2">
            <ul>
                <li class="p-4 flex items-center justify-center bg-yellow-700 cursor-pointer hover:bg-opacity-40">
                    Sub Sub Panel21
                </li>
                <li class="p-4 flex items-center justify-center bg-emerald-700 cursor-pointer hover:bg-opacity-40">
                    Sub Sub Pane22
                </li>
            </ul>
        </div>
    </div>
</template>

<script setup>
    import { ref, onMounted } from 'vue';
    import PanelItem from './PanelItem.vue';

    const visibleTabLevel1 = ref(0);
    const visibleSubTabLevel2 = ref(0);
    const isMinimized = ref(false);

    const handleClick = (visibleTab) => {
        visibleTabLevel1.value = visibleTab;
    }
/*
    const handleClickSubTab = (visbleSubTab) => {
        visibleSubTabLevel2.value = visbleSubTab;
    }*/


    const handleMinimizeScreenClick = () => {
        isMinimized.value = true
        parentDiv.value.style.width = `50px`;
    }

    const handleResetScreenClick = () => {
        isMinimized.value = false
        parentDiv.value.style.width = `200px`;
    }

    const handleFullScreenClick = () => {
        parentDiv.value.style.width = `100vw`;
    }

    const handleHalfScreenClick = () => {
        parentDiv.value.style.width = `50%`;
    }




    const parentDiv = ref(null);
    const resizer = ref(null);
    const isMouseDown = ref(false);

    onMounted(() => {
        resizer.value.addEventListener("mousedown", () => {
            isMouseDown.value = true;
        });

        window.addEventListener("mousemove", (e) => {
            if (!isMouseDown.value) return;

            const newWidth = e.clientX - parentDiv.value.getBoundingClientRect().left;
            if (newWidth < 200 || newWidth > 600) return;

            parentDiv.value.style.width = `${newWidth}px`;
        });

        window.addEventListener("mouseup", () => {
            isMouseDown.value = false;
        });
    })
</script>
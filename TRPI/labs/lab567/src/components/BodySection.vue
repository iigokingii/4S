<template>
    <div class="Bodyst">
        <div>
            <BISectionItem v-for="BigI in listBI" :key="BigI.id" v-bind:BI="BigI"/>
        </div>
        <div class="MedItems">
            <MedSectionItem v-for="MedI in listMed" :key="MedI.id" v-bind:MedI="MedI"/>
        </div>
        <div class="LittItems">
            <transition-group name="List">
                <LittISection v-for="LittI in listLitt" :key="LittI.id" v-bind:LittI="LittI"/>
            </transition-group>
        </div>
    </div>   
</template>
  
<script>
import BISectionItem from '@/components/BISectionItem.vue';
import MedSectionItem from './MedSectionItem.vue';
import LittISection from './LittISection.vue';
    export default{
        props:{
            listBI:{
                type:Array,
                required:true,
            },
            listMed:{
                type:Array,
                required:true
            },
            listLitt:{
                type:Array,
                required:true,
            }
        },
        components:{ BISectionItem, MedSectionItem,LittISection }
    }
</script>
<style src="@/styles/BodySection.css" scoped>
    
</style>
  
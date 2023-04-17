<template>
    <div class ="header" >
        <img id="im" :src="require (`../images/${ImageSrc}`)">
        <div class="headerItems">
            <div class="headerElem" v-for="liItem in liItems" :key="liItem.id" v-bind:liItem="liItem">
                {{ liItem.Text }}
            </div>
        </div>
    </div>   
</template>
  
<script>
    export default{
        props:{
            ImageSrc:{
                type:String,
                required:true
            },
            liItems:{
                type:Array,
                required:true,
            }, 
        }
    }
</script>
<style src="@/styles/HeaderList.css" scoped>
    
</style>
  
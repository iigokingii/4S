<template>
    <div id="LittIStyle">
        <img id="im" :src="require (`@/images/${LittI.imgS}`)">
        <div class="text">
            <p class="Title">
                {{ LittI.Title }}
            </p>
            <p class="Description">
            {{ LittI.Description }}
            </p>
        </div>
    </div>
</template>
<script>
    export default{
        props:{
            LittI:{
                type:Object,
                required:true
            }
        }
    }
</script>
<style src="@/styles/LittlSection.css" scoped>
    
</style>
   
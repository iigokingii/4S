<template>
    <div id="MedStyle">
        <img id="im" :src="require (`@/images/${MedI.imgS}`)">
        <div class="text">
            <p class="Title">
                {{ MedI.Title }}
            </p>
            <p class="Description">
            {{ MedI.Description }}
            </p>
        </div>
    </div>
</template>

<script>
    export default{
        props:{
            MedI:{
                type:Object,
                required:true
            }
        }
    }
</script>
<style src="@/styles/MedSectionItem.css" scoped>

</style>
  
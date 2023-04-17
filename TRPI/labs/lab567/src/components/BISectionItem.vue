<template>
    <div id="BIStyle">
        <img id="im" :src="require (`@/images/${BI.imgS}`)">
        <div class="text">
            <p class="Title">
                {{ BI.Title }}
            </p>
            <p class="Description">
            {{ BI.Description }}
            </p>
        </div>
    </div>
</template>
<script>
    export default{
        props:{
            BI:{
                type:Object,
                required:true
            }
        }
    }
</script>
<style src="@/styles/BISectionItem.css" scoped>
</style>
  
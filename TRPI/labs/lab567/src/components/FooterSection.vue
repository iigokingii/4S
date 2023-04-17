<template>
    <div class="Footer">
        <div class="FooterImages">
                <img id="FooterIm" :src="require (`../images/${footerBlackRect}`)"/>
                <img id="FooterIm" :src="require (`../images/${footerBlackRect}`)"/>
                <img id="FooterIm" :src="require (`../images/${footerBlackRect}`)"/>
                <img id="FooterIm" :src="require (`../images/${footerBlackRect}`)"/>
        </div>
        <div class="Wrapper">
            <img id="Footerlogo" v-bind:src="require (`../images/${footerImage}`)">
        </div>
        
        <p class="FooterText">{{ footerText }}</p>
    </div>
</template>
  
<script>
    export default{
        props:{
            footerImage:{
                type:String,
                required:true,
            },
            footerText:{
                type:String,
                required:true,
            },
            footerBlackRect:{
                type:String,
                required:true
            }
        }
    }
</script>
<style src="@/styles/FooterSectionStyle.css" scoped>
    
</style>
  
<template>
  <div class="Content">
    <HeaderList v-bind:liItems="liItems" v-bind:ImageSrc="srcIconc"/>
    <BodySection v-bind:listBI="listBI" :listMed="listMed" :listLitt="listLitt"/>
    <ItemForm @AddToListBI ="AddItem"/>
    <FooterSection :footerImage="footerImage" :footerText="footerText" :footerBlackRect="footerBlackRect"/>
  </div>
</template>

<script>
import HeaderList from "@/components/HeaderList.vue";
import BodySection from "./components/BodySection.vue";
import FooterSection from "./components/FooterSection.vue";
import ItemForm from "./components/ItemForm.vue";
export default{
  components:{HeaderList, BodySection,FooterSection,ItemForm},
  data(){
    return{
      srcIconc:"logo.svg",
      liItems:[
        {id:1,Text:"ART & DESIGN"},
        {id:2,Text:"NOUVELLES"},
        {id:3,Text:"À PROPOS"},
        {id:4,Text:"CONTACT"},
      ],
      listBI:[
        {id:1,imgS:"IMAGE1.png" , Title:"Variations sur un fil", Description:"VANNERIES MINIATURES"},
        {id:2,imgS:"IMAGE2.png" , Title:"Vanneries Exploratoires", Description:"OEUVRES TEXTILES"},
      ],
      listMed:[
        {id:1,imgS:"IMAGE3.png",Title:"Collection Sand",Description:"Loïc & Monique"},
        {id:2,imgS:"IMAGE4.png",Title:"Collection Chanvre",Description:"OBJETS TISSÉS"},
      ],
      listLitt:[
        {id:1,imgS:"IMAGE5.png",Title:"Correspondances 1",Description:"EXPOSITION COLLECTIVE"},
        {id:2,imgS:"IMAGE6.png",Title:"Abris intuitifs",Description:"EXPOSITION SOLO"},
        {id:3,imgS:"IMAGE7.png",Title:"Correspondances 2",Description:"EXPOSITION COLLECTIVE"},
      ],
      Title:"",
      Description:"",
      footerBlackRect:"Rect.png",
      footerText:"© sainte marie textile 2020",
      footerImage:"footer.png"
    }
  },
  methods:{
    AddItem(BI){
      this.listLitt.push(BI);
    }
  }
}
</script>
<style src="@/styles/App.css" scoped>
  
</style>

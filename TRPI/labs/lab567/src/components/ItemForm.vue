<template>
    <div>  
        <form @submit.prevent>
            <h4>Создание поста</h4>
            <input v-model="BI.Title" class="input" type="text" placeholder="Название">
            <input v-model="BI.Description" class="input" type="text" placeholder="Описание">
            <input v-model="BI.imgS" class="input" type="text" placeholder="Название картинки из папки Image">
            <button class="btn" @click="createBI">Создать</button>
        </form>
    </div>
</template>
<script>
    export default{
        data(){
            return{
                BI:{
                    id:'',
                    Title:'',
                    Description:'',
                    imgS:'',
                },
            }
        },
        methods:{
            createBI(){
                this.BI.id = Date.now();
                this.BI.imgS +=".jpg";
                this.$emit(`AddToListBI`,this.BI);
                this.BI={
                    id:'',
                    Title:'',
                    Description:''
                }
            }
        }
    }
</script>
<style>
    form{
        display: flex;
        flex-direction: column;
    }
    .input{
        width: 96.6%;
        border: 1px solid teal;
        padding: 10px 15px;
        margin-top: 15px;
    }
    .btn{
        margin-top: 15px;
        align-self: flex-end;
        padding: 10px 15px;
        background: none;
        color: teal;
        border: 1px solid teal;
    }
</style>
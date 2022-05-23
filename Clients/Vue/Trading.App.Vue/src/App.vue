<template>
    <h1>Trade Purchaser</h1>
    <router-view></router-view>
    <Footer></Footer>
</template>

<script>
    import Footer from './components/Footer'
export default {
  name: 'App',
        components: {
            Footer
  }
}
</script>

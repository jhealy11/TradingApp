<template>
    <h1>Trade Purchaser</h1>
    <Button />
    <hr/>
    <Trades />
</template>

<script>
    import Button from './components/Button'
    import Trades from './components/Trades'
    
export default {
  name: 'App',
        components: {
            Button,
            Trades
  }
}
</script>

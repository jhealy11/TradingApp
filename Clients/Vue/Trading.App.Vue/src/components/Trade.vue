<template>
    <td>
        {{trade.id}}
    </td>
    <td>
        {{trade.security}}
    </td>
    <td>
        {{trade.quantity}}
    </td>
    <td>
        {{trade.price}}
    </td>
    <td>
        {{trade.tradeDate}}
    </td>
    <td>
        {{trade.buySell}}
    </td>

</template>



<script>

    export default {
        name: 'Trade',
        props: {
            trade: Object
        }
    }
</script>
<template>
    <h3>Existing Trades</h3>

    <table class="table table-striped">
        <thead>
            <tr>
                <th>Id</th>
                <th>Stock</th>
                <th>Quantity</th>
                <th>Price</th>
                <th>Trade Date</th>
                <th>Buy/Sell</th>
            </tr>
        </thead>
        <tbody>
            <tr :key="trade.id" v-for="trade in trades">
                <Trade :trade="trade" />
            </tr>

            <!--<tr v-for="trade in trades"
                v-bind:key="trade.id">
                <Trade v-bind:trade="trade" />
            </tr>-->
        </tbody>
    </table>
</template>



<script>

    import Trade from './Trade'


    export default {
        name: 'Trades',

        data: () => ({
            trades: null
        }),
        methods: {
            async fetchTrades() {
            fetch('https://localhost:7006/api/Trade')
                    .then(async response => {

                        const data = await response.json();

                        if (!response.ok) {
                            const error = (data && data.message) || response.status;
                            return Promise.reject(error)
                        }

                        this.trades = data;
                    })
                    .catch(error => {
                        alert("Error is " + error.message)
                        console.error("Error is", error)
                    });
            }
        },
        created() {
            this.fetchTrades()
        },
        components: {
            Trade
        }
    }
</script>
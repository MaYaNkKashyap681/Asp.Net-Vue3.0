const path = require('path');

module.exports = {
    outputDir: path.resolve(__dirname, './wwwroot/dist'),
    productionSourceMap: false,
    filenameHashing: false,
    css: {
        extract: {
            filename: 'globalstyle.css'
        }
    },
    configureWebpack: {
        optimization: {
            splitChunks: false
        },
        output: {
            filename: 'app.js'
        },
        resolve: {
            alias: {
                'vue$': 'vue/dist/vue.esm-bundler.js'
            }
        }
    }
}

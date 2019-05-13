// joi ref https://github.com/hapijs/joi/blob/v14.3.1/API.md
const frisby = require('frisby');
const Joi = frisby.Joi;
const baseUrl = 'http://localhost:5000';

describe('TV Series', function () {
    it('should create, read, and delete series', async function () {

        for (const series of seriesJson) {
            await frisby.post(`${baseUrl}/api/series`, series)
                                            .expectNot('status', 500);
            
            const getResponse = await frisby.get(`${baseUrl}/api/series/${series.id}`)
                                                .expect('status', 200);
            expect(getResponse.json.id).toBe(series.id);
            expect(getResponse.json.name).toBe(series.name);
        }

       
        
        await frisby.get(`${baseUrl}/api/series`)
                    .expect('status', 200)
                    .expect('jsonTypes', Joi.array().length(seriesJson.length))
                    .expect('jsonTypes', '*', {
                        'id': Joi.number().required(),
                        'name': Joi.string().required()
                    });
        
        

        // tear down - delete every series
        
        for (const series of seriesJson) {
            await frisby.del(`${baseUrl}/api/series/${series.id}`)
                    .expectNot('status', 500);
        }
        

        await frisby.get(`${baseUrl}/api/series`)
                        .expect('status', 200)
                        .expect('jsonTypes', Joi.array().length(0));
    }, 30000);
});

const seriesJson = [{
        id: 1,
        name: 'Home Improvement'
    },{
        id: 2,
        name: 'Full House'
    },{
        id: 3,
        name: 'Boy Meets World'
    }
];

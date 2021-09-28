import http from 'k6/http';
import { sleep } from 'k6';
export let options = {
    vus: 50,
    duration: '30s',
    thresholds: {
        http_req_duration: ['p(95)<250'],
    },
};
export default function () {
    http.get('http://devopspipelinescodetesting.azurewebsites.net/');
    sleep(1);
}
